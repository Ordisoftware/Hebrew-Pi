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
/// <edited> 2025-01-14 </edited>
namespace Ordisoftware.Hebrew.Pi;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
public partial class MainForm
{
  private long MotifSize = 10;
  private int BufferSize = 10_000_000;
  private int CreateDataPaging = 100000;
  private int CreateDataEstimatePaging = 100000;
  private string CreateDataProgress = $"{{0}} inserted";

  private async Task DoActionDbCreateData(string fileName)
  {
    StreamReader reader = null;
    if ( !File.Exists(fileName) )
      DisplayManager.Show(SysTranslations.FileNotFound.GetLang(fileName));
    else
      try
      {
        UpdateStatusInfo(EmptyingTablesText);
        DB.Connection.DeleteAll<DecupletRow>();
        DB.Connection.DeleteAll<IterationRow>();
        UpdateStatusInfo(PopulatingText);
        DB.Connection.BeginTransaction();
        UpdateStatusProgress(string.Format(CreateDataProgress, "0"));
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
          for ( long indexBuffer = 0; indexBuffer < charsRead; indexBuffer += MotifSize )
            if ( indexBuffer + MotifSize <= charsRead )
            {
              if ( Globals.CancelRequired ) break;
              while ( Globals.PauseRequired ) await Task.Delay(500);
              motif = 0;
              for ( long indexMotif = 0; indexMotif < MotifSize; indexMotif++ )
              {
                long shiftLeft = motif << 1;
                motif = ( shiftLeft << 2 ) + shiftLeft + buffer[indexBuffer + indexMotif] - 48;
                // motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
              }
              DB.Connection.Insert(new DecupletRow { Motif = motif });
              totalMotifs++;
              if ( totalMotifs % CreateDataPaging == 0 )
                UpdateStatusProgress(string.Format(CreateDataProgress, totalMotifs.ToString("N0")));
              if ( totalMotifs % CreateDataEstimatePaging == 0 )
              {
                double progress = (double)( totalMotifs * 10 ) / fileSize;
                var elapsed = Globals.ChronoProcess.Elapsed;
                var remaining = TimeSpan.FromSeconds(( elapsed.TotalSeconds / progress ) - elapsed.TotalSeconds);
                UpdateStatusInfo(string.Format(PopulatingAndRemainingText, remaining.AsReadable()));
              }
            }
        }
        UpdateStatusInfo(CommittingText);
        DB.Connection.Commit();
        UpdateStatusInfo(IndexingText);
        DB.Connection.CreateIndex(DecupletRow.TableName, nameof(DecupletRow.Motif), false);
        if ( Globals.CancelRequired )
          UpdateStatusInfo(CanceledText);
        else
          UpdateStatusInfo(FinishedText);
        reader.Close();
      }
      catch ( Exception ex )
      {
        UpdateStatusInfo(ex.Message);
      }
      finally
      {
        Globals.PauseRequired = false;
        Globals.CancelRequired = false;
        if ( reader is not null )
        {
          reader.Close();
          reader.Dispose();
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
