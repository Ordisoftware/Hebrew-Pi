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

using CountMotifsAndMaxOccurencesTuple = (long CountMotifs, long MaxOccurrences);

abstract class ReduceRepeatingSqlBase : ReduceRepeatingBase
{

  public override void CreateUniqueRepeatingMotifsTempTable()
  {
    CheckDatabaseNotNull();
    string table = $"{MainForm.Instance.NameWorkingDB}.UniqueRepeatingMotifs";
    if ( DB.CheckTable(table)
     && !DisplayManager.QueryYesNo("table already exists, use it without populate it?") )
      return;
    DB.DropTableIfExists(table);
    DB.Execute($"""
                CREATE TABLE {table} AS
                SELECT Motif, COUNT(*) AS Occurrences
                FROM Decuplets
                GROUP BY Motif
                HAVING COUNT(*) > 1
                """);
  }

  public override List<CountMotifsAndMaxOccurencesTuple> GetUniqueRepeatingStats()
  {
    CheckDatabaseNotNull();
    return DB.Query<CountMotifsAndMaxOccurencesTuple>($"""
                                                       SELECT
                                                         COUNT(*) AS UniqueRepeating,
                                                         MAX(Occurrences) AS MaxOccurrences
                                                       FROM {MainForm.Instance.NameWorkingDB}.UniqueRepeatingMotifs
                                                       """);
  }

  public override void CreateAllRepeatingMotifsTempTable()
  {
    CheckDatabaseNotNull();
    string table = $"{MainForm.Instance.NameWorkingDB}.AllRepeatingMotifs";
    if ( DB.CheckTable(table)
     && !DisplayManager.QueryYesNo("table already exists, use it without populate it?") )
      return;
    DB.DropTableIfExists($"{table}");
    DB.Execute($"CREATE TABLE {table} (Position INTEGER PRIMARY KEY)");
    DB.Execute($"""
                INSERT INTO {table} (Position)
                SELECT Position
                FROM Decuplets
                WHERE Motif IN (SELECT Motif FROM {MainForm.Instance.NameWorkingDB}.UniqueRepeatingMotifs)
                """);
  }

  public override long CountAllRepeatingMotifs()
  {
    CheckDatabaseNotNull();
    return DB.ExecuteScalar<long>($"SELECT COUNT(*) FROM {MainForm.Instance.NameWorkingDB}.AllRepeatingMotifs");
  }

}
