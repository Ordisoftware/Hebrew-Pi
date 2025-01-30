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

class SqlWithTempLoopPosPK : SqlBase
{

  public override void CreateAllRepeatingMotifsTempTable(SQLiteNetORM DB)
  {
    DB.Execute("DROP TABLE IF EXISTS AllRepeatingMotifs");
    DB.Execute("CREATE TEMPORARY TABLE AllRepeatingMotifs (Position INTEGER PRIMARY KEY)");
    var sql = @"INSERT INTO AllRepeatingMotifs (Position)
                SELECT Position
                FROM Decuplets
                WHERE Motif IN (SELECT Motif FROM UniqueRepeatingMotifs)";
    DB.Execute(sql);
  }

  public override long CountAllRepeatingMotifs(SQLiteNetORM DB)
  {
    return DB.ExecuteScalar<long>("SELECT COUNT(*) FROM Decuplets WHERE Motif IN (SELECT Motif FROM UniqueRepeatingMotifs)");
  }

  public override long AddPositionToRepeatingMotifs(SQLiteNetORM DB)
  {
    long step = 0;
    long pagingCommit = MainForm.Instance.AllRepeatingCount > 100_000_100 ? 10_000_000 : 1_000_000;
    MainForm.Instance.RepeatingAddedCount = 0;
    List<PositionWithMotifRow> items = null;
    while ( true )
    {
      items = DB.Query<PositionWithMotifRow>($"select * from AllRepeatingMotifs limit {pagingCommit} offset {step}");
      if ( items.Count == 0 ) break;
      foreach ( var item in items )
      {
        DB.Execute($"update Decuplets set Motif = Motif + Position where Position = {item.Position}");
        MainForm.Instance.RepeatingAddedCount++;
      }
      step += pagingCommit;
    }
    return MainForm.Instance.RepeatingAddedCount;
  }

}
