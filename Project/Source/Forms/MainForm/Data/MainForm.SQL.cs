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

record struct CountMotifsAndMaxOccurences(long CountMotifs, long MaxOccurrences);

abstract class SqlHelperBase
{

  public void CreateUniqueRepeatingMotifsTempTable(SQLiteNetORM DB)
  {
    DB.Execute("DROP TABLE IF EXISTS UniqueRepeatingMotifs");
    var sql = @"CREATE TEMPORARY TABLE UniqueRepeatingMotifs AS
                SELECT Motif, COUNT(*) AS Occurrences
                FROM Decuplets
                GROUP BY Motif
                HAVING COUNT(*) > 1";
    DB.Execute(sql);
  }

  public List<CountMotifsAndMaxOccurences> GetUniqueRepeatingStats(SQLiteNetORM DB)
  {
    return DB.Query<CountMotifsAndMaxOccurences>("SELECT COUNT(*) AS UniqueRepeating, MAX(Occurrences) AS MaxOccurrences FROM UniqueRepeatingMotifs");
  }

  abstract public void CreateAllRepeatingMotifsTempTable(SQLiteNetORM DB);

  abstract public long CountAllRepeatingMotifs(SQLiteNetORM DB);

  abstract public long AddPositionToRepeatingMotifs(SQLiteNetORM DB);
}
