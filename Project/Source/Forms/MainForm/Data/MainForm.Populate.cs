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

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private const long PiDecimalMotifSize = 10;
  private int FileReadBufferSize = 10_000_000;

  private async Task DoActionPopulate(string filePathText)
  {
    if ( !File.Exists(filePathText) )
    {
      DisplayManager.Show(SysTranslations.FileNotFound.GetLang(filePathText));
      return;
    }
    long fileSize = SystemManager.GetFileSize(filePathText);
    long pagingProgress = fileSize <= 1_100_000 ? 1_000 : fileSize <= 10_100_000 ? 10_000 : 100_000;
    long pagingCommit = fileSize <= 1_100_000_000 ? 10_100_000 : 100_000_000;
    long countRows = 0;
    long countMotifs = 0;
    bool isAppend = false;
    bool hasError = false;
    StreamReader reader = null;
    try
    {
      checkRows();
      UpdateStatusInfo(AppTranslations.PopulatingText);
      UpdateStatusProgress(string.Format(AppTranslations.CreateDataProgress, "0"));
      DB.BeginTransaction();
      long motif = 0;
      int charsRead;
      char[] buffer = new char[FileReadBufferSize];
      reader = new StreamReader(filePathText);
      charsRead = reader.Read(buffer, 0, 2);
      if ( charsRead != 2 )
      {
        DisplayManager.Show(SysTranslations.LoadFileError.GetLang(filePathText, fileSize.FormatBytesSize()));
        return;
      }
      string str = new string(buffer, 0, 2);
      reader.Close();
      reader.Dispose();
      reader = new StreamReader(filePathText);
      if ( str == "3." || str == "3," )
      {
        reader.BaseStream.Seek(2, SeekOrigin.Begin);
        fileSize -= 2;
      }
      while ( ( charsRead = reader.Read(buffer, 0, FileReadBufferSize) ) >= 10 )
      {
        if ( !CheckIfBatchCanContinue().Result ) break;
        for ( long indexBuffer = 0; indexBuffer < charsRead; indexBuffer += PiDecimalMotifSize )
        {
          if ( ( !isAppend || countMotifs >= countRows ) && indexBuffer + PiDecimalMotifSize <= charsRead )
          {
            if ( !CheckIfBatchCanContinue().Result ) break;
            motif = buffer[indexBuffer] - 48; // motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
            for ( long indexMotif = 1; indexMotif < PiDecimalMotifSize; indexMotif++ )
            {
              long shiftLeft = motif << 1;
              motif = ( shiftLeft << 2 ) + shiftLeft + buffer[indexBuffer + indexMotif] - 48;
            }
            DB.Insert(new DecupletRow { Position = countMotifs + 1, Motif = motif });
            if ( countMotifs % pagingCommit == 0 ) doCommit(true);
          }
          if ( countMotifs % pagingProgress == 0 ) showProgress();
          countMotifs++;
        }
      }
      doCommit();
      if ( CheckIfBatchCanContinue().Result )
      {
        UpdateStatusInfo(AppTranslations.IndexingText);
        DB.CreateIndex(DecupletRow.TableName, nameof(DecupletRow.Motif), false);
      }
    }
    catch ( Exception ex )
    {
      hasError = true;
      try
      {
        doCommit();
      }
      catch
      {
        doRollback();
      }
      UpdateStatusInfo(ex.Message);
    }
    finally
    {
      if ( reader is not null )
      {
        reader.Close();
        reader.Dispose();
      }
      if ( !hasError )
        if ( Globals.CancelRequired )
          UpdateStatusInfo(AppTranslations.CanceledText);
        else
          UpdateStatusInfo(AppTranslations.FinishedText);
    }
    //
    void doCommit(bool partial = false)
    {
      UpdateStatusProgress(string.Format(AppTranslations.CreateDataProgress, countMotifs.ToString("N0")));
      UpdateStatusInfo(AppTranslations.CommittingText);
      DB.Commit();
      if ( partial ) DB.BeginTransaction();
    }
    void doRollback()
    {
      UpdateStatusProgress(string.Format(AppTranslations.CreateDataProgress, countMotifs.ToString("N0")));
      UpdateStatusInfo(AppTranslations.RollbackText);
      DB.Rollback();
    }
    //
    void showProgress()
    {
      var elapsed = Globals.ChronoBatch.Elapsed;
      double size1 = ( countMotifs - countRows ) * PiDecimalMotifSize;
      double size2 = fileSize - countRows * PiDecimalMotifSize;
      double progress = size1 == 0 || size2 == 0 ? 1 : size1 / size2;
      var remaining = TimeSpan.FromSeconds(( elapsed.TotalSeconds / progress ) - elapsed.TotalSeconds);
      UpdateStatusInfo(string.Format(AppTranslations.PopulatingAndRemainingText, remaining.AsReadable()));
      UpdateStatusProgress(string.Format(AppTranslations.CreateDataProgress, countMotifs.ToString("N0")));
    }
    //
    void checkRows()
    {
      countRows = DB.CountRows(DecupletRow.TableName);
      if ( countRows > 0 )
      {
        string title = "Table is not empty";
        string msg = $"""
                        Table has {countRows.ToString("N0")} rows already inserted.

                        Do you want to continue inserting the decuplets, clear everything and start over, or cancel?
                        """;
        using var form = new MessageBoxEx(title, msg,
                                          width: MessageBoxEx.DefaultWidthMedium,
                                          buttons: MessageBoxButtons.YesNo,
                                          icon: MessageBoxIcon.Question,
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
            isAppend = true;
            break;
          case DialogResult.No:
            UpdateStatusInfo(AppTranslations.EmptyingTablesText);
            DB.DeleteAll<DecupletRow>();
            DB.DeleteAll<IterationRow>();
            break;
          case DialogResult.Cancel:
            Globals.CancelRequired = true;
            return;
        }
      }
    }

  }

  //private void CreateDataTable()
  //{
  //  try
  //  {
  //    var dataTable = new DataTable();
  //    var command = DB.CreateCommand("SELECT * FROM Decuplets LIMIT 1000000 OFFSET 0");
  //    var list = command.ExecuteQuery<DecupletRow>();
  //    if ( list.Count > 0 )
  //    {
  //      foreach ( var prop in typeof(DecupletRow).GetProperties() )
  //        dataTable.Columns.Add(prop.Name);
  //      foreach ( var row in list )
  //      {
  //        var dataRow = dataTable.NewRow();
  //        foreach ( var prop in typeof(DecupletRow).GetProperties() )
  //          dataRow[prop.Name] = prop.GetValue(row);
  //        dataTable.Rows.Add(dataRow);
  //      }
  //    }
  //    Grid.DataSource = dataTable;
  //  }
  //  catch ( Exception ex )
  //  {
  //    UpdateStatusInfo(ex.Message);
  //  }
  //}

}
