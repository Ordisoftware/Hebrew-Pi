using Microsoft.WindowsAPICodePack.Taskbar;

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
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private bool DoScreenPositionMutex;

  /// <summary>
  /// Enables double-buffering.
  /// </summary>
  protected override CreateParams CreateParams
  {
    get
    {
      var cp = base.CreateParams;
      if ( Settings.WindowsDoubleBufferingEnabled )
      {
        cp.ExStyle |= Globals.WS_EX_COMPOSITED;
        //cp.Style &= Globals.WS_CLIPCHILDREN;
      }
      return cp;
    }
  }

  /// <summary>
  /// Centers the form to the screen.
  /// </summary>
  public new void CenterToScreen()
  {
    base.CenterToScreen();
  }

  /// <summary>
  /// Executes the screen location operation.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void DoScreenPosition(object sender, EventArgs e)
  {
    if ( DoScreenPositionMutex ) return;
    try
    {
      DoScreenPositionMutex = true;
      if ( sender is ToolStripMenuItem menuItem )
      {
        foreach ( ToolStripMenuItem item in ( (ToolStripMenuItem)menuItem.OwnerItem ).DropDownItems )
          item.Checked = item == menuItem;
      }
      if ( Globals.IsReady ) Settings.Store();
      this.SetLocation(Settings.MainFormPosition);
    }
    finally
    {
      DoScreenPositionMutex = false;
    }
  }

  private void UpdateButtons()
  {
    void update()
    {
      bool dbOpened = DB is not null;
      bool dbOnenedAndNotInBatch = dbOpened && !Globals.IsInBatch;
      bool dbOnenedAndInBatch = dbOpened && Globals.IsInBatch;
      Globals.AllowClose = !Globals.IsInBatch;
      SelectDbCache.Enabled = !Globals.IsInBatch;
      SelectPiDecimalsFile.Enabled = !Globals.IsInBatch;
      EditMaxMotifs.Enabled = !Globals.IsInBatch;
      ActionDbOpen.Enabled = !dbOpened;
      ActionDbNew.Enabled = ActionDbOpen.Enabled;
      ActionDbClose.Enabled = dbOnenedAndNotInBatch;
      ActionCreateData.Enabled = dbOnenedAndNotInBatch;
      ActionNormalize.Enabled = dbOnenedAndNotInBatch;
      ActionCreateIndex.Enabled = dbOnenedAndNotInBatch && !IsMotifIndexed;
      ActionStop.Enabled = dbOnenedAndInBatch && Globals.CanCancel;
      ActionPause.Enabled = ( dbOnenedAndInBatch && Globals.CanPause && !Globals.PauseRequired )
                         || ( dbOnenedAndInBatch && Globals.PauseRequired );
      ActionPause.Text = Globals.PauseRequired ? "Continue" : "Pause";

    }
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(update);
    else
      update();
  }

  private void ClearStatusBar()
  {
    void update()
    {
      LabelStatusTimeBatch.Text = "Batch: N/A";
      LabelStatusTimeSubBatch.Text = "Sub-batch: N/A";
      LabelStatusRemaining.Text = AppTranslations.RemainingNAText;
      LabelStatusInfo.Text = "Info: N/A";
      LabelStatusAction.Text = "Action: N/A";
    }
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(update);
    else
      update();
  }

  private void UpdateStatusLabel(ToolStripStatusLabel label, string text)
  {
    void update()
    {
      label.Text = text;
      StatusStrip.Refresh();
    }
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(update);
    else
      update();
  }

  private void UpdateStatusAction(string text)
  {
    UpdateStatusLabel(LabelStatusAction, AppTranslations.ActionText + text);
  }

  private void UpdateStatusInfo(string text)
  {
    UpdateStatusLabel(LabelStatusInfo, AppTranslations.InfoText + text);
  }

  private void UpdateStatusRemaining(string text)
  {
    UpdateStatusLabel(LabelStatusRemaining, text);
  }

  private void DoTimerMemory()
  {
    LabelStatusFreeMem.Text = "Free memory: " + SystemManager.PhysicalMemoryFreeValue.FormatBytesSize();
    LabelTitleRight.Text = DB is null
      ? "CLOSED"
      : $"OPENED ({SystemManager.GetFileSize(DatabaseFilePath).FormatBytesSize()})";
  }

  private void DoTimerStatus()
  {
    LabelStatusTimeBatch.Text = Globals.ChronoBatch.Elapsed.TotalSeconds == 0
      ? "Batch: N/A"
      : string.Format(AppTranslations.BatchElapsedText, Globals.ChronoBatch.Elapsed.AsReadable());
    LabelStatusTimeSubBatch.Text = Globals.ChronoSubBatch.Elapsed.TotalSeconds == 0
      ? "Sub-batch: N/A"
      : string.Format(AppTranslations.SubBatchElapsedText, Globals.ChronoSubBatch.Elapsed.AsReadable());
    switch ( Processing )
    {
      case ProcessingType.CreateData:
        UpdateStatusAction(Operation.ToString());
        UpdateStatusInfo(string.Format(AppTranslations.CreateDataProgress, MotifsProcessedCount.ToString("N0")));
        try
        {
          var elapsed = Globals.ChronoBatch.Elapsed;
          long max = PiDecimalsFileSize / PiDecimalMotifSize;
          max = Math.Min(PiDecimalsFileSize, (long)EditMaxMotifs.Value);
          double countDone = MotifsProcessedCount - DecupletsRowCount;
          double countToDo = max - DecupletsRowCount;
          double progress = countDone <= 0 || countToDo <= 0 ? 1 : countDone / countToDo;
          var remaining = TimeSpan.FromSeconds(( elapsed.TotalSeconds / progress ) - elapsed.TotalSeconds);
          UpdateStatusRemaining(string.Format(AppTranslations.RemainingText, remaining.AsReadable()));
          TaskbarManager.Instance.SetProgressValue((int)( progress * 100 ), 100);
        }
        catch ( Exception ex )
        {
          UpdateStatusRemaining(ex.Message);
        }
        break;
      case ProcessingType.ReduceRepeating:
        UpdateStatusAction(Operation.ToString());
        UpdateStatusInfo(string.Format(AppTranslations.IterationText, ReduceRepeatingIteration, MotifsProcessedCount));
        break;
      default:
        LabelStatusRemaining.Text = AppTranslations.RemainingNAText;
        break;
    }
  }

}