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
/// <created> 2025-01-10 </created>
/// <edited> 2025-01-15 </edited>
namespace Ordisoftware.Hebrew.Pi;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private long MotifSize = 10;
  private int BufferSize = 10_000_000;
  private int CreateDataPaging = 100000;
  private int CreateDataEstimatePaging = 100000;

  private async Task DoActionDbCreateData(string fileName)
  {
    StreamReader reader = null;
    if ( !File.Exists(fileName) )
      DisplayManager.Show(SysTranslations.FileNotFound.GetLang(fileName));
    else
      try
      {
        UpdateStatusInfo(AppTranslations.EmptyingTablesText);
        DB.DeleteAll<DecupletRow>();
        DB.DeleteAll<IterationRow>();
        UpdateStatusInfo(AppTranslations.PopulatingText);
        DB.BeginTransaction();
        UpdateStatusProgress(string.Format(AppTranslations.CreateDataProgress, "0"));
        int charsRead;
        long totalMotifs = 0;
        long motif = 0;
        char[] buffer = new char[BufferSize];
        long fileSize = SystemManager.GetFileSize(fileName);
        reader = new StreamReader(fileName);
        charsRead = reader.Read(buffer, 0, 2);
        if ( charsRead != 2 )
          throw new IndexOutOfRangeException(fileName);
        reader.Close();
        reader.Dispose();
        reader = new StreamReader(fileName);
        if ( new string(buffer) == "3," )
          reader.BaseStream.Seek(2, SeekOrigin.Current);
        while ( ( charsRead = reader.Read(buffer, 0, BufferSize) ) > 0 )
        {
          if ( !CheckIfProcessingCanContinue().Result ) break;
          for ( long indexBuffer = 0; indexBuffer < charsRead; indexBuffer += MotifSize )
            if ( indexBuffer + MotifSize <= charsRead )
            {
              if ( !CheckIfProcessingCanContinue().Result ) break;
              motif = buffer[indexBuffer] - 48; // motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
              for ( long indexMotif = 1; indexMotif < MotifSize; indexMotif++ )
              {
                long shiftLeft = motif << 1;
                motif = ( shiftLeft << 2 ) + shiftLeft + buffer[indexBuffer + indexMotif] - 48;
              }
              DB.Insert(new DecupletRow { Position = totalMotifs + 1, Motif = motif });
              totalMotifs++;
              if ( totalMotifs % CreateDataPaging == 0 )
                UpdateStatusProgress(string.Format(AppTranslations.CreateDataProgress, totalMotifs.ToString("N0")));
              if ( totalMotifs % CreateDataEstimatePaging == 0 )
              {
                double progress = (double)( totalMotifs * 10 ) / fileSize;
                var elapsed = Globals.ChronoProcess.Elapsed;
                var remaining = TimeSpan.FromSeconds(( elapsed.TotalSeconds / progress ) - elapsed.TotalSeconds);
                UpdateStatusInfo(string.Format(AppTranslations.PopulatingAndRemainingText, remaining.AsReadable()));
              }
            }
        }
        if ( CheckIfProcessingCanContinue().Result )
        {
          UpdateStatusInfo(AppTranslations.CommittingText);
          DB.Commit();
        }
        else DB.Rollback();
        if ( CheckIfProcessingCanContinue().Result )
        {
          UpdateStatusInfo(AppTranslations.IndexingText);
          DB.CreateIndex(DecupletRow.TableName, nameof(DecupletRow.Motif), false);
        }
      }
      catch ( Exception ex )
      {
        UpdateStatusInfo(ex.Message);
      }
      finally
      {
        if ( reader is not null )
        {
          reader.Close();
          reader.Dispose();
        }
        if ( Globals.CancelRequired )
          UpdateStatusInfo(AppTranslations.CanceledText);
        else
          UpdateStatusInfo(AppTranslations.FinishedText);
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
