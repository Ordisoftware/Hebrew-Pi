using Equin.ApplicationFramework;

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

  private void LoadIterationGrid()
  {
    GridIterations.DataSource = new BindingListView<IterationRow>(DB.Table<IterationRow>().ToList());
  }

  private void DoActionDbOpen(string path)
  {
    DatabaseFilePath = path;
    LabelTitleCenter.Text = Path.GetFileName(path);
    DB = new SQLiteNetORM(path);
    if ( SQLiteTempDir.Length > 0 )
      DB.SetTempDir(SQLiteTempDir);
    DB.CreateTable<DecupletRow>();
    DB.CreateTable<IterationRow>();
    SetDbCache();
    LoadIterationGrid();
    UpdateButtons();
    TimerMemory_Tick(null, null);
  }

  private void DoActionDbClose()
  {
    if ( DB is null ) return;
    DB.Close();
    DB.Dispose();
    DB = null;
    UpdateButtons();
    TimerMemory_Tick(null, null);
  }

  private void DoActionRun()
  {
    switch ( Settings.CurrentView )
    {
      case ViewMode.Populate:
        //if ( !DisplayManager.QueryYesNo("Empty and create data?") ) return;
        DoBatch(() => DoActionPopulate(Path.Combine(Globals.DocumentsFolderPath, GetSelectedFileName(".txt"))));
        break;
      case ViewMode.Normalize:
        //if ( !DisplayManager.QueryYesNo("Start reducing repeating motifs?") ) return;
        DoBatch(() => DoActionNormalize(0));
        break;
      default:
        throw new AdvNotImplementedException(Settings.CurrentView);
    }
  }

  private async Task DoBatch(Action action)
  {
    try
    {
      ClearStatusBar();
      SetBatchState(true);
      UpdateButtons();
      Globals.ChronoBatch.Restart();
      TimerBatch_Tick(null, null);
      TimerBatch.Enabled = true;
      await Task.Run(async () => action());
    }
    finally
    {
      Globals.ChronoBatch.Stop();
      TimerBatch.Enabled = false;
      SetBatchState(false);
      UpdateButtons();
    }
  }

  private void SetBatchState(bool active)
  {
    Globals.IsInBatch = active;
    Globals.PauseRequired = false;
    Globals.CancelRequired = false;
  }

  private void DoActionStop()
  {
    Globals.CancelRequired = true;
  }

  private void DoActionPauseContinue()
  {
    Globals.PauseRequired = !Globals.PauseRequired;
    UpdateButtons();
    if ( Globals.PauseRequired )
      Globals.ChronoBatch.Stop();
    else
      Globals.ChronoBatch.Start();
  }

  private async Task<bool> CheckIfBatchCanContinue()
  {
    if ( Globals.CancelRequired ) return false;
    while ( Globals.PauseRequired && !Globals.CancelRequired )
      await Task.Delay(500);
    return true;
  }

}
