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
      ActionDbOpen.Enabled = !dbOpened;
      ActionDbNew.Enabled = ActionDbOpen.Enabled;
      ActionDbClose.Enabled = dbOnenedAndNotInBatch;
      ActionCreateData.Enabled = dbOnenedAndNotInBatch;
      ActionNormalize.Enabled = dbOnenedAndNotInBatch;
      ActionCreateIndex.Enabled = dbOnenedAndNotInBatch && !IsMotifIndexed;
      ActionStop.Enabled = dbOnenedAndInBatch && Globals.CanCancel;
      ActionPause.Enabled = dbOnenedAndInBatch && Globals.CanPause && !Globals.PauseRequired;
      ActionContinue.Enabled = dbOnenedAndInBatch && Globals.PauseRequired;
      //ActionContinue.Visible = Globals.PauseRequired;
      //ActionPause.Visible = !ActionContinue.Visible;
      ActionStop2.Enabled = ActionStop.Enabled;
      ActionPause2.Enabled = ActionPause.Enabled || ActionContinue.Enabled;
      ActionPause2.Text = Globals.PauseRequired ? "Continue" : "Pause";

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
      LabelStatusTimeSubBatch.Text = "SubBatch: N/A";
      LabelStatusRemaining.Text = AppTranslations.RemainingNAText;
      LabelStatusInfo.Text = "Info: N/A";
      LabelStatusAction.Text = "Action: N/A";
    }
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(update);
    else
      update();
  }

  private void UpdateStatusAction(string text)
  {
    UpdateStatusLabel(LabelStatusAction, text);
  }

  private void UpdateStatusInfo(string text)
  {
    UpdateStatusLabel(LabelStatusInfo, text);
  }

  private void UpdateStatusRemaining(string text)
  {
    UpdateStatusLabel(LabelStatusRemaining, text);
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

  private void DoTimerMemory()
  {
    LabelStatusFreeMem.Text = "Free memory: " + SystemManager.PhysicalMemoryFreeValue.FormatBytesSize();
    LabelTitleRight.Text = DB is null
      ? "CLOSED"
      : $"OPENED ({SystemManager.GetFileSize(DatabaseFilePath).FormatBytesSize()})";
  }

  private void DoTimerBatch()
  {
    LabelStatusTimeBatch.Text = Globals.ChronoBatch.Elapsed.TotalSeconds == 0
      ? "Batch: N/A"
      : string.Format(AppTranslations.BatchElapsedText, Globals.ChronoBatch.Elapsed.AsReadable());
    LabelStatusTimeSubBatch.Text = Globals.ChronoSubBatch.Elapsed.TotalSeconds == 0
      ? "SubBatch: N/A"
      : string.Format(AppTranslations.SubBatchElapsedText, Globals.ChronoSubBatch.Elapsed.AsReadable());
  }

  //
  // Update history buttons
  //
  private void UpdateHistoryButtons()
  {
    //  if ( CurrentReference is null )
    //  {
    //    ActionHistoryVerseNext.Enabled = false;
    //    ActionHistoryVerseBack.Enabled = false;
    //    return;
    //  }
    //  var list = HistoryItems.ToList();
    //  int index = list.FindIndex(r => r.CompareTo(CurrentReference) == 0);
    //  if ( index == -1 )
    //  {
    //    ActionHistoryVerseNext.Enabled = false;
    //    ActionHistoryVerseBack.Enabled = false;
    //    return;
    //  }
    //  var view = Settings.CurrentView;
    //  bool canHistoryMove = IsVersesOrTranslationOrOriginal(view);
    //  ActionHistoryVerseNext.Enabled = canHistoryMove && index != 0;
    //  ActionHistoryVerseBack.Enabled = canHistoryMove && index != list.Count - 1;
    //}

    //[SuppressMessage("Major Bug", "S2583:Conditionally executed code should be reachable", Justification = "Analysis error")]
    //internal void UpdateTitle(bool forceView = false)
    //{
    //  if ( !Globals.IsReady ) return;
    //  LabelTitleReferenceName.Text = " " + CurrentReference?.ToStringBasedOnPreferences().ToUpper() ?? string.Empty;
    //  LabelTitleReferenceName.Refresh();
    //  if ( forceView )
    //  {
    //    LabelTitle.Text = AppTranslations.ViewPanelTitle.GetLang(Settings.CurrentView).ToUpper();
    //    LabelTitle.Refresh();
    //  }
  }

}
