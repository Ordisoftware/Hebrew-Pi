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

public class ReduceRepeatingSqlLoop : ReduceRepeatingSqlBase
{

  public override long AddPositionToRepeatingMotifs()
  {
    CheckDatabaseNotNull();
    string querySelect = $"SELECT Position FROM {MainForm.Instance.TableFullNameAllRepeatingMotifs} LIMIT {{0}} OFFSET {{1}}";
    string queryUpdate = "UPDATE Decuplets SET Motif = Motif + Position WHERE Position = {0}";
    long pagingLoading = 1_000_000;
    long pagingCommit = MainForm.Instance.AllRepeatingCount > 1_000_000_100 ? 100_000_000 : 10_000_000;
    long step = 0;
    MainForm.Instance.RepeatingAddedCount = 0;
    List<long> positions;
    do
    {
      if ( !MainForm.Instance.CheckIfBatchCanContinueAsync().Result && DisplayManager.QueryYesNo("Cancel adding?") )
        break;
      MainForm.Instance.Operation = OperationType.LoadingMotifs;
      positions = DB.QueryScalars<long>(string.Format(querySelect, pagingLoading, step));
      MainForm.Instance.Operation = OperationType.LoadedMotifs;
      MainForm.Instance.Operation = OperationType.Adding;
      if ( !DB.IsInTransaction )
        if ( positions.Count != 0 )
          DB.BeginTransaction();
        else
          break;
      foreach ( var position in positions )
      {
        DB.Execute(string.Format(queryUpdate, position));
        MainForm.Instance.RepeatingAddedCount++;
      }
      step += pagingLoading;
      if ( step % pagingCommit == 0 ) doCommit();
    }
    while ( positions.Count != 0 );
    if ( DB.IsInTransaction ) doCommit();
    return MainForm.Instance.RepeatingAddedCount;
    //
    void doCommit()
    {
      MainForm.Instance.Operation = OperationType.Committing;
      DB.Commit();
      MainForm.Instance.Operation = OperationType.Committed;
    }
  }

}
