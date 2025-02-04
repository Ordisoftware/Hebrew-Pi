/// <license>
/// file is part of Ordisoftware Hebrew Pi.
/// Copyright 2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2025-01 </created>
/// <edited> 2025-01 </edited>
namespace Ordisoftware.Hebrew.Pi;

using Bio;

using CountMotifsAndMaxOccurences = (long CountMotifs, long MaxOccurrences);

abstract class ReduceRepeatingBaseBigList : ReduceRepeatingBase
{

  protected SQLiteNetORM DB => MainForm.Instance.DB;

  protected void CheckDatabaseNotNull()
  {
    if ( DB is null ) throw new ArgumentNullException("DB");
  }

  private BigList<CountMotifsAndMaxOccurences> UniqueRepeatingMotifs = new();

  public override void CreateUniqueRepeatingMotifsTempTable()
  {
    CheckDatabaseNotNull();
    DB.Execute("DROP TABLE IF EXISTS UniqueRepeatingMotifs");
    DB.Execute("""
               CREATE TEMPORARY TABLE UniqueRepeatingMotifs AS
               SELECT Motif, COUNT(*) AS Occurrences
               FROM Decuplets
               GROUP BY Motif
               HAVING COUNT(*) > 1
               """);
  }

  public override List<CountMotifsAndMaxOccurences> GetUniqueRepeatingStats()
  {
    CheckDatabaseNotNull();
    return DB.Query<CountMotifsAndMaxOccurences>("""
                                                  SELECT
                                                    COUNT(*) AS UniqueRepeating,
                                                    MAX(Occurrences) AS MaxOccurrences
                                                  FROM UniqueRepeatingMotifs
                                                  """);
  }

  public override void CreateAllRepeatingMotifsTempTable()
  {
    CheckDatabaseNotNull();
    DB.Execute("DROP TABLE IF EXISTS AllRepeatingMotifs");
    DB.Execute("CREATE TEMPORARY TABLE AllRepeatingMotifs (Position INTEGER PRIMARY KEY)");
    DB.Execute("""
               INSERT INTO AllRepeatingMotifs (Position)
               SELECT Position
               FROM Decuplets
               WHERE Motif IN (SELECT Motif FROM UniqueRepeatingMotifs)
               """);
  }

  public override long CountAllRepeatingMotifs()
  {
    CheckDatabaseNotNull();
    return DB.ExecuteScalar<long>("SELECT COUNT(*) FROM AllRepeatingMotifs");
  }

  public override long AddPositionToRepeatingMotifs()
  {
    CheckDatabaseNotNull();
    const string querySelect = "SELECT * FROM AllRepeatingMotifs LIMIT {0} OFFSET {1}";
    const string queryUpdate = "UPDATE Decuplets SET Motif = Motif + Position WHERE Position = {0}";
    long pagingCommit = MainForm.Instance.AllRepeatingCount > 10_000_100 ? 1_000_000 : 100_000;
    long step = 0;
    MainForm.Instance.RepeatingAddedCount = 0;
    List<long> positions;
    do
    {
      if ( !MainForm.Instance.CheckIfBatchCanContinueAsync().Result && DisplayManager.QueryYesNo("Cancel adding?") )
        break;
      positions = DB.QueryScalars<long>(string.Format(querySelect, pagingCommit, step));
      MainForm.Instance.Operation = OperationType.Adding;
      DB.BeginTransaction();
      foreach ( var position in positions )
      {
        DB.Execute(string.Format(queryUpdate, position));
        MainForm.Instance.RepeatingAddedCount++;
      }
      MainForm.Instance.Operation = OperationType.Committing;
      DB.Commit();
      MainForm.Instance.Operation = OperationType.Committed;
      step += pagingCommit;
    }
    while ( positions.Count != 0 );
    return MainForm.Instance.RepeatingAddedCount;
  }

}
