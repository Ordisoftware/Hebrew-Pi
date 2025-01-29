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

using Equin.ApplicationFramework;
using Microsoft.WindowsAPICodePack.Taskbar;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private bool IsMotifIndexed;

  [DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl)]
  public static extern void sqlite3_interrupt(IntPtr db);

  private void LoadIterationGrid()
  {
    GridIterations.SyncUISimple(() =>
    {
      GridIterations.DataSource = new BindingListView<IterationRow>(DB.Table<IterationRow>().ToList());
      GridIterations.ClearSelection();
    });
  }

  private async Task DoBatchAsync(Action action, bool interruptible = true)
  {
    if ( Processing != ProcessingType.None ) return;
    try
    {
      SetBatchState(true, interruptible);
      UpdateButtons();
      ClearStatusBar();
      await Task.Run(async () => action());
    }
    finally
    {
      Globals.ChronoBatch.Stop();
      Globals.ChronoSubBatch.Stop();
      SetBatchState(false);
      UpdateButtons();
      switch ( Processing )
      {
        case ProcessingType.Finished:
        case ProcessingType.Canceled:
          UpdateStatusAction(Processing.ToString());
          break;
        case ProcessingType.Error:
          UpdateStatusAction(Processing.ToString() + ": " + Except.Message.Replace(Environment.NewLine, " "));
          break;
      }
      Processing = ProcessingType.None;
    }
  }

  private void SetBatchState(bool active, bool interruptible = true)
  {
    Globals.IsInBatch = active;
    Globals.PauseRequired = false;
    Globals.CancelRequired = false;
    Globals.CanCancel = interruptible;
    Globals.CanPause = interruptible;
  }

  private void DoActionStop()
  {
    Globals.CancelRequired = true;
    if ( CanForceTerminateBatch )
      sqlite3_interrupt(DB.Handle.DangerousGetHandle());
  }

  private void DoActionPauseContinue()
  {
    Globals.PauseRequired = !Globals.PauseRequired;
    TaskbarManager.Instance.SetProgressState(Globals.PauseRequired ? TaskbarProgressBarState.Paused : TaskbarProgressBarState.Normal);
    UpdateButtons();
    if ( Globals.PauseRequired )
      Globals.ChronoBatch.Stop();
    else
      Globals.ChronoBatch.Start();
  }

  private async Task<bool> CheckIfBatchCanContinueAsync()
  {
    if ( Globals.CancelRequired ) return false;
    while ( Globals.PauseRequired && !Globals.CancelRequired )
      await Task.Delay(500);
    return true;
  }

}
