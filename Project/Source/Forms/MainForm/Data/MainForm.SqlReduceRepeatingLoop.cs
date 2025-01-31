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

class SqlReduceRepeatingLoop : SqlReduceRepeating
{

  public override long AddPositionToRepeatingMotifs(SQLiteNetORM DB)
  {
    const string querySelect = "SELECT * FROM AllRepeatingMotifs LIMIT {0} OFFSET {1}";
    const string queryUpdate = "UPDATE Decuplets SET Motif = Motif + Position WHERE Position = {0}";
    long pagingCommit = MainForm.Instance.AllRepeatingCount > 10_000_100 ? 1_000_000 : 100_000;
    long step = 0;
    MainForm.Instance.RepeatingAddedCount = 0;
    List<PositionWithMotifRow> items = null;
    var cases = new StringBuilder();
    var positions = new List<long>();
    do
    {
      if ( !MainForm.Instance.CheckIfBatchCanContinueAsync().Result && DisplayManager.QueryYesNo("Cancel adding?") )
        break;
      items = DB.Query<PositionWithMotifRow>(string.Format(querySelect, pagingCommit, step));
      DB.BeginTransaction();
      MainForm.Instance.Operation = OperationType.Adding;
      foreach ( var item in items )
      {
        DB.Execute(string.Format(queryUpdate, item.Position));
        MainForm.Instance.RepeatingAddedCount++;
      }
      MainForm.Instance.Operation = OperationType.Committing;
      DB.Commit();
      MainForm.Instance.Operation = OperationType.Committed;
      step += pagingCommit;
    }
    while ( items.Count != 0 );
    return MainForm.Instance.RepeatingAddedCount;
  }

}
