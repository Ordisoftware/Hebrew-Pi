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
/// <edited> 2025-01-11 </edited>
namespace Ordisoftware.Hebrew.Pi;

using SQLite;

public partial class MainForm
{

  private SQLiteConnection _connection;
  private int _iterationCount = 0;

  private async void DoActionCreateTable()
  {
    ActionCreateTable.Enabled = false;
    await Task.Run(() =>
    {
      chrono = new Stopwatch();
      chrono.Start();
      CreateTable(Path.Combine(Globals.DocumentsFolderPath, FileName.ToString()) + ".txt");
      chrono.Stop();
      UpdateStatusTime();
    });
    ActionCreateTable.Enabled = true;
  }

  private async void CreateTable(string fileName)
  {
    string dbPath = Path.Combine(Globals.DatabaseFolderPath, FileName.ToString()) + Globals.DatabaseFileExtension;
    try
    {
      if ( DB is not null )
      {
        DB.Close();
        DB.Dispose();
      }
      DB = new SQLiteConnection(dbPath);
      DB.CreateTable<DecupletRow>();
      DB.BeginTransaction();
      UpdateStatusInfo($"0k - Started");
      int charsRead;
      int blockSize = 10;
      long totalBlocks = 0;
      long motif = 0;
      int bufferLength = 10_000_000;
      char[] buffer = new char[bufferLength];
      using var reader = new StreamReader(fileName);
      while ( ( charsRead = reader.Read(buffer, 0, bufferLength) ) > 0 )
      {
        for ( int indexBuffer = 0; indexBuffer < charsRead; indexBuffer += blockSize )
          if ( indexBuffer + blockSize <= charsRead )
          {
            motif = 0;
            for ( int indexMotif = 0; indexMotif < blockSize; indexMotif++ )
              motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
            DB.Insert(new DecupletRow { Motif = motif });
            totalBlocks++;
            if ( totalBlocks % 1000000 == 0 )
              UpdateStatusInfo($"{totalBlocks / 1000}k blocs insérés");
          }
      }
      UpdateStatusInfo($"{totalBlocks / 1000}k - Committing");
      DB.Commit();
      UpdateStatusInfo($"{totalBlocks / 1000}k - Indexing");
      DB.Execute($"CREATE INDEX idx_decuplets_value ON {DecupletRow.TableName} ({nameof(DecupletRow.Motif)})");
      UpdateStatusInfo($"{totalBlocks / 1000}k - Finished");
    }
    catch ( Exception ex )
    {
      UpdateStatusInfo($"Error : {ex.Message}");
    }
  }

  private void CreateDataTable()
  {
    try
    {
      var dataTable = new DataTable();
      var command = DB.CreateCommand("SELECT * FROM Decuplets LIMIT 1000000 OFFSET 0");
      var list = command.ExecuteQuery<DecupletRow>();
      if ( list.Count > 0 )
      {
        foreach ( var prop in typeof(DecupletRow).GetProperties() )
          dataTable.Columns.Add(prop.Name);
        foreach ( var row in list )
        {
          var dataRow = dataTable.NewRow();
          foreach ( var prop in typeof(DecupletRow).GetProperties() )
            dataRow[prop.Name] = prop.GetValue(row);
          dataTable.Rows.Add(dataRow);
        }
      }
      Grid.DataSource = dataTable;
    }
    catch ( Exception ex )
    {
      UpdateStatusInfo(ex.Message);
    }
  }

  public async Task ProcessPiDecimalsAsync()
  {
    while ( true )
    {
      _iterationCount++;
      var duplicateCount = CountDuplicateMotifs();
      Console.WriteLine($"Itération {_iterationCount}: Nombre de motifs dupliqués : {duplicateCount}");
      Console.WriteLine("Voulez-vous effectuer une autre itération ? (O/N)");
      string response = Console.ReadLine();
      if ( response.ToUpper() != "O" )
        break;
      UpdateMotifs();
      if ( duplicateCount == 0 )
      {
        Console.WriteLine("Aucun motif dupliqué trouvé, le processus est terminé.");
        break;
      }
    }
    _connection.Close();
  }

  private int CountDuplicateMotifs()
  {
    var query = @"SELECT COUNT(DISTINCT Motif) AS UniqueDuplicates
                  FROM Decuplets
                  WHERE Motif IN (
                    SELECT Motif
                    FROM Decuplets
                    GROUP BY Motif
                    HAVING COUNT(Motif) > 1
                  );";

    return _connection.Query<int>(query).FirstOrDefault();
  }

  private void UpdateMotifs()
  {
    var query = @"UPDATE Decuplets
                  SET Motif = Motif + Position
                  WHERE Motif IN (
                    SELECT Motif
                    FROM Decuplets
                    GROUP BY Motif
                    HAVING COUNT(*) > 1
                  );";
    _connection.Execute(query);
  }

}
