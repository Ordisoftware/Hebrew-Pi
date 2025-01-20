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

  static internal async Task<List<(long MotifCount, long MaxOccurences)>> GetRepeatingMotifCountAndMaxOccurencesAsync(this SQLiteNetORM DB)
  {
    var sql = @"SELECT COUNT(*) AS Nombre_Motifs_Uniques, MAX(Occurrences) AS Occurrence_Max
                FROM (
                  SELECT Motif, COUNT(*) AS Occurrences
                  FROM Decuplets
                  GROUP BY Motif
                  HAVING COUNT(*) > 1);";
    return [.. DB.Query<(long MotifCount, long MaxOccurences)>(sql)];
  }

  static internal async Task AddPositionToRepeatingMotifsAsync(this SQLiteNetORM DB)
  {
    var sql = @"UPDATE Decuplets
                SET Motif = Motif + Position
                WHERE Motif IN (
                  SELECT Motif
                  FROM Decuplets
                  GROUP BY Motif
                  HAVING COUNT(*) > 1
                );";
    DB.Execute(sql);
  }

  //static internal async Task<int> GetRepeatingMotifsCountAsync(this SQLiteNetORM DB)
  //{
  //  var sql = @"SELECT COUNT(DISTINCT Motif) AS UniqueRepeated
  //              FROM Decuplets
  //              WHERE Motif IN (
  //                SELECT Motif
  //                FROM Decuplets
  //                GROUP BY Motif
  //                HAVING COUNT(Motif) > 1
  //              );";
  //  return DB.QueryScalars<int>(sql).Single();
  //}

  //static internal async Task<int> GetRepeatingMotifsMaxOccurencesAsync(this SQLiteNetORM DB)
  //{
  //  var sql = @"SELECT MAX(Occurrences) AS MaxDuplicates
  //              FROM (
  //                SELECT COUNT(*) AS Occurrences
  //                FROM Decuplets
  //                GROUP BY Motif
  //                HAVING COUNT(*) > 1
  //              );";
  //  return DB.QueryScalars<int>(sql).Single();
  //}

  //static internal async Task<List<(long Motif, long Occurences)>> GetRepeatingMotifsAndMaxOccurencesAsync(this SQLiteNetORM DB)
  //{
  //  var sql = @"SELECT Motif, COUNT(*) AS Occurrences
  //              FROM Decuplets
  //              GROUP BY Motif
  //              HAVING COUNT(*) > 1
  //              ORDER BY Occurrences DESC;";
  //  return [.. DB.Query<(long Motif, long Occurences)>(sql)];
  //}

}
