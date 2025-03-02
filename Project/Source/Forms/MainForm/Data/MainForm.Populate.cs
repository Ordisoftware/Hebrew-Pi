﻿/// <license>
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
    long motif;
    long shiftLeft;
    long maxMotifsCount = (long)EditMaxMotifs.Value;
    long maxLoopMotifs;
    bool maxReached = false;
    int charsRead;
    int readBufferSize = PiDecimalsFileSize > 1_000_000_100 ? 100_000_000 : 10_000_000;
    long pagingCommit = PiDecimalsFileSize > 1_000_000_100 ? 100_000_000 : 10_000_000;
    long pagingCurrent;
    bool hasError = false;
    char[] buffer = new char[readBufferSize];
    StreamReader reader = null;
    try
    {
      reader = new StreamReader(filePathText);
      Processing = ProcessingType.CreateData;
      Globals.ChronoSubBatch.Restart();
      Operation = OperationType.CountingAllRows;
      Globals.ChronoSubBatch.Restart();
      DecupletsRowCount = DB.CountRows(DecupletRow.TableName);
      Globals.ChronoSubBatch.Stop();
      Operation = OperationType.CountedAllRows;
      if ( DecupletsRowCount > 0 )
        AskWhatToDoOnNonEmptyTable();
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
        reader.BaseStream.Seek(DecupletsRowCount * PiDecimalMotifSize, SeekOrigin.Current);
        MotifsProcessedCount = DecupletsRowCount;
      }
      else
        MotifsProcessedCount = 0;
      TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
      Operation = OperationType.Populating;
      DB.BeginTransaction();
      Globals.ChronoBatch.Restart();
      while ( ( charsRead = reader.Read(buffer, 0, readBufferSize) ) >= PiDecimalMotifSize && !maxReached )
      {
        maxLoopMotifs = charsRead - PiDecimalMotifSize;
        for ( int indexBuffer = 0; indexBuffer <= maxLoopMotifs; indexBuffer += PiDecimalMotifSize )
        {
          if ( MotifsProcessedCount >= maxMotifsCount || !CheckIfBatchCanContinueAsync().Result )
            maxReached = true;
          else
          {
            motif = buffer[indexBuffer] - 48;
            for ( int indexMotif = 1; indexMotif < PiDecimalMotifSize; indexMotif++ )
            {
              // motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
              shiftLeft = motif << 1;
              motif = ( shiftLeft << 2 ) + shiftLeft + buffer[indexBuffer + indexMotif] - 48;
            }
            MotifsProcessedCount++;
            DB.Insert(new DecupletRow { Position = MotifsProcessedCount, Motif = motif });
            if ( MotifsProcessedCount % pagingCommit == 0 )
              DoCommit(true);
          }
        }
      }
      if ( MotifsProcessedCount == 9_999_999_999 ) // Fix for pi_dec_1t_01.txt from pi_dec_1t_02.txt
        DB.Insert(new DecupletRow { Position = ++MotifsProcessedCount, Motif = 0191295669 });
      DoCommit();
      UpdateStatusInfo(string.Format(AppTranslations.CreateDataProgress, MotifsProcessedCount.ToString("N0")));
      if ( !CheckIfBatchCanContinueAsync().Result ) return;
      if ( EditAutoCreateIndex.Checked )
        DoCreateIndexAsync();
    }
    catch ( Exception ex )
    {
      Processing = ProcessingType.Error;
      hasError = true;
      try
      {
        DoCommit();
      }
      catch
      {
        DoRollback();
      }
      Except = ex;
      ex.Manage(ex);
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
  }

}
