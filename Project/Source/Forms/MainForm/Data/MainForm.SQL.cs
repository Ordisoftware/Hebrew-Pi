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

static class SQLHelper
{

  static internal async Task CreateUniqueRepeatingAndOccurencesTempTableAsync(this SQLiteNetORM DB)
  {
    DB.Execute("DROP TABLE IF EXISTS UniqueRepeatingMotifs");
    var sql = @"CREATE TEMPORARY TABLE UniqueRepeatingMotifs AS
                SELECT Motif, COUNT(*) AS Occurrences
                FROM Decuplets
                GROUP BY Motif
                HAVING COUNT(*) > 1";
    DB.Execute(sql);
  }

  static internal async Task<List<(long MotifCount, long MaxOccurrences)>> GetUniqueRepeatingCountAndMaxOccurencesAsync(this SQLiteNetORM DB)
  {
    var sql = @"SELECT COUNT(*) AS UniqueRepeating, MAX(Occurrences) AS MaxOccurrences
                FROM UniqueRepeatingMotifs";
    return [.. DB.Query<(long MotifCount, long MaxOccurrences)>(sql)];
  }

  //static internal async Task<long> CountAllRepeatingMotifs(this SQLiteNetORM DB)
  //{
  //  var sql = @"SELECT COUNT(*)
  //              FROM Decuplets AS Pool
  //              WHERE Pool.Motif IN (SELECT Motif FROM UniqueRepeatingMotifs)";
  //  return DB.ExecuteScalar<long>(sql);
  //}

  static internal async Task<long> AddPositionToRepeatingMotifsAsync(this SQLiteNetORM DB)
  {
    var sql = @"UPDATE Decuplets
                SET Motif = Motif + Position
                WHERE Motif IN (SELECT Motif FROM UniqueRepeatingMotifs)";
    int signedResult = DB.Execute(sql);
    return unchecked((uint)signedResult);
  }

}
