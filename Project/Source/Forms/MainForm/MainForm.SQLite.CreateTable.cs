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
  private const int CreateDataPaging = 100000;
  private string CreateDataProgress = $"{{0}} inserted";

  private void DoActionDbCReate(string fileName)
  {
    StreamReader reader = null;
    if ( !File.Exists(fileName) )
      DisplayManager.Show(SysTranslations.FileNotFound.GetLang(fileName));
    else
      try
      {
        UpdateStatusInfo("Dropping tables...");
        DB.DropTable<DecupletRow>();
        DB.DropTable<IterationRow>();
        UpdateStatusInfo("Creating tables...");
        DB.CreateTable<DecupletRow>();
        DB.CreateTable<IterationRow>();
        UpdateStatusInfo("Populating...");
        DB.BeginTransaction();
        UpdateStatusProgress(string.Format(CreateDataProgress, "0"));
        int charsRead;
        long totalMotifs = 0;
        long motif = 0;
        char[] buffer = new char[BufferSize];
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
              motif = 0;
              for ( long indexMotif = 0; indexMotif < MotifSize; indexMotif++ )
              {
                long shiftLeft = motif << 1;
                motif = ( shiftLeft << 2 ) + shiftLeft + buffer[indexBuffer + indexMotif] - 48;
                // motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
              }
              DB.Insert(new DecupletRow { Motif = motif });
              totalMotifs++;
              if ( totalMotifs % CreateDataPaging == 0 )
                UpdateStatusProgress(string.Format(CreateDataProgress, totalMotifs.ToString("N0")));
            }
        }
        UpdateStatusInfo(CommittingText);
        DB.Commit();
        UpdateStatusInfo(IndexingText);
        string sql = $"CREATE INDEX idx_decuplets_value ON {DecupletRow.TableName} ({nameof(DecupletRow.Motif)})";
        DB.Execute(sql);
        UpdateStatusInfo(FinishedText);
        reader.Close();
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
