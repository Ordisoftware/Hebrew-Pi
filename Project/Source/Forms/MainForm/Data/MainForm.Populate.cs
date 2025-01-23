/// <license>
/// This file is part of Ordisoftware Hebrew Pi.
/// Copyright 2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2025-01 </created>
/// <edited> 2025-01 </edited>
namespace Ordisoftware.Hebrew.Pi;

using Microsoft.WindowsAPICodePack.Taskbar;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private async Task DoActionPopulateAsync(string filePathText)
  {
    if ( !File.Exists(filePathText) )
    {
      DisplayManager.Show(SysTranslations.FileNotFound.GetLang(filePathText));
      return;
    }
    long pagingCommit = PiDecimalsFileSize <= 1_100_000_000 ? 1_000_000 : 10_000_000;
    bool hasError = false;
    bool maxReached = false;
    StreamReader reader = null;
    try
    {
      long maxMotifsCount = (long)EditMaxMotifs.Value;
      long motif;
      long shiftLeft;
      int charsRead;
      char[] buffer = new char[FileReadBufferSize];
      reader = new StreamReader(filePathText);
      Processing = ProcessingType.CreateData;
      Globals.ChronoSubBatch.Restart();
      checkRows();
      Globals.ChronoSubBatch.Stop();
      charsRead = reader.Read(buffer, 0, 2);
      if ( charsRead != 2 )
      {
        DisplayManager.Show(SysTranslations.LoadFileError.GetLang(filePathText, PiDecimalsFileSize.FormatBytesSize()));
        return;
      }
      string str = new(buffer, 0, 2);
      reader.Close();
      reader.Dispose();
      reader = new StreamReader(filePathText);
      if ( str == "3." || str == "3," )
      {
        reader.BaseStream.Seek(2, SeekOrigin.Begin);
        PiDecimalsFileSize -= 2;
      }
      if ( DecupletsRowCount > 0 )
      {
        reader.BaseStream.Seek(DecupletsRowCount * PiDecimalMotifSize, SeekOrigin.Begin);
        MotifsProcessedCount = DecupletsRowCount;
      }
      else
        MotifsProcessedCount = 0;
      TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
      Operation = OperationType.Populating;
      DB.BeginTransaction();
      Globals.ChronoBatch.Restart();
      while ( ( charsRead = reader.Read(buffer, 0, FileReadBufferSize) ) >= PiDecimalMotifSize && !maxReached )
      {
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        for ( long indexBuffer = 0; indexBuffer < charsRead; indexBuffer += PiDecimalMotifSize )
        {
          if ( !CheckIfBatchCanContinueAsync().Result ) break;
          if ( MotifsProcessedCount >= maxMotifsCount )
          {
            maxReached = true;
            break;
          }
          if ( indexBuffer + PiDecimalMotifSize <= charsRead )
          {
            motif = buffer[indexBuffer] - 48; // motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
            for ( long indexMotif = 1; indexMotif < PiDecimalMotifSize; indexMotif++ )
            {
              shiftLeft = motif << 1;
              motif = ( shiftLeft << 2 ) + shiftLeft + buffer[indexBuffer + indexMotif] - 48;
            }
            DB.Insert(new DecupletRow { Position = MotifsProcessedCount + 1, Motif = motif });
            if ( MotifsProcessedCount % pagingCommit == 0 )
              doCommit(true);
          }
          MotifsProcessedCount++;
        }
      }
      doCommit();
      UpdateStatusInfo(string.Format(AppTranslations.CreateDataProgress, MotifsProcessedCount.ToString("N0")));
    }
    catch ( Exception ex )
    {
      Processing = ProcessingType.Error;
      hasError = true;
      try
      {
        doCommit();
      }
      catch
      {
        doRollback();
      }
      Except = ex;
    }
    finally
    {
      TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
      if ( reader is not null )
      {
        reader.Close();
        reader.Dispose();
      }
      if ( !hasError )
        if ( Globals.CancelRequired )
          Processing = ProcessingType.Canceled;
        else
          Processing = ProcessingType.Finished;
    }
    //
    void doCommit(bool partial = false)
    {
      Operation = OperationType.Committing;
      Globals.ChronoSubBatch.Restart();
      DB.Commit();
      Globals.ChronoSubBatch.Stop();
      Operation = OperationType.Committed;
      if ( partial )
      {
        DB.BeginTransaction();
        Operation = OperationType.Populating;
      }
    }
    void doRollback()
    {
      Operation = OperationType.Rollbacking;
      Globals.ChronoSubBatch.Restart();
      DB.Rollback();
      Globals.ChronoSubBatch.Stop();
      Operation = OperationType.Rollbacked;
    }
    //
    void checkRows()
    {
      Operation = OperationType.Counting;
      Globals.ChronoSubBatch.Restart();
      DecupletsRowCount = DB.CountRows(DecupletRow.TableName);
      Globals.ChronoSubBatch.Stop();
      Operation = OperationType.Counted;
      if ( DecupletsRowCount > 0 )
        AskWhatToDoOnNonEmptyTable();
    }
  }

  private void AskWhatToDoOnNonEmptyTable()
  {
    string title = "Table is not empty";
    string msg = $"""
                        Table has {DecupletsRowCount:N0} rows already inserted.

                        Do you want to continue inserting the decuplets, clear everything and start over, or cancel?
                        """;
    using var form = new MessageBoxEx(title, msg,
                                      buttons: MessageBoxButtons.YesNo,
                                      icon: MessageBoxIcon.Question,
                                      width: MessageBoxEx.DefaultWidthMedium,
                                      justify: false,
                                      showInTaskBar: true);
    if ( !Globals.MainForm.Visible || Globals.MainForm.WindowState == FormWindowState.Minimized )
      form.StartPosition = FormStartPosition.CenterScreen;
    form.ActionCancel.Visible = true;
    form.ActionYes.Text = "Continue";
    form.ActionNo.Text = "Empty";
    form.ActionCancel.Text = "Cancel";
    form.ActiveControl = form.ActionYes;
    switch ( form.ShowDialog() )
    {
      case DialogResult.Yes:
        break;
      case DialogResult.No:
        Operation = OperationType.Emptying;
        Globals.ChronoSubBatch.Restart();
        DB.DropTable<DecupletRow>();
        DB.DropTable<IterationRow>();
        DB.CreateTable<DecupletRow>();
        DB.CreateTable<IterationRow>();
        Globals.ChronoSubBatch.Stop();
        DecupletsRowCount = 0;
        Operation = OperationType.Emptied;
        break;
      case DialogResult.Cancel:
        Globals.CancelRequired = true;
        return;
    }
  }

}
