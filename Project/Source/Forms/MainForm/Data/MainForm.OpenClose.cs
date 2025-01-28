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

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private async void DoActionDbOpenAsync(string path)
  {
    if ( DB is not null ) DoActionDbCloseAsync();
    Operation = OperationType.Opening;
    Globals.ChronoBatch.Restart();
    DatabaseFilePath = path;
    DB = new SQLiteNetORM(path);
    DB.SetTempStoreMode(SQLiteTempStoreMode.FILE);
    DB.SetJournal(SQLiteJournalMode.OFF);
    DB.SetSynchronous(SQLiteSynchronousMode.OFF);
    DB.SetLocking(SQLiteLockingMode.EXCLUSIVE);
    DB.SetPageSize(SQLitePageSize._32768);
    DB.SetTempDir(EditTempDir.Text);
    SetDbCache();
    DB.CreateTable<DecupletRow>();
    DB.CreateTable<IterationRow>();
    IsMotifIndexed = DB.CheckIndex("Decuplets_Motif");
    Globals.ChronoBatch.Stop();
    Operation = OperationType.Opened;
    LabelTitleCenter.Invoke(() => LabelTitleCenter.Text = Path.GetFileName(path));
    LoadIterationGrid();
    UpdateButtons();
  }

  private async void DoActionDbCloseAsync()
  {
    if ( DB is null ) return;
    Operation = OperationType.Closing;
    Globals.ChronoBatch.Restart();
    DB.Close();
    Globals.ChronoBatch.Stop();
    DB.Dispose();
    DB = null;
    GridIterations.Invoke(() => GridIterations.DataSource = null);
    GridIterations.Invoke(() => LabelTitleCenter.Text = string.Empty);
    UpdateButtons();
    Operation = OperationType.Closed;
  }

}