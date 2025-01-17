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

using Microsoft.Win32;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm : Form
{

  /// <summary>
  /// Does constructor
  /// </summary>
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  private void DoConstructor()
  {
    Interlocks.Take();
    InitializeViewConnectors();
    new Task(InitializeIconsAndSound).Start();
    new Task(InitializeDialogsDirectory).Start();
    //new Task(() => BookmarkItems = new Bookmarks(Program.BookmarksFilePath)).Start();
    //new Task(() => HistoryItems = new History(Program.HistoryFilePath)).Start();
    SystemManager.TryCatch(() => Icon = new Icon(Globals.ApplicationIconFilePath));
    Text = Globals.AssemblyTitle;
    ToolStrip.Renderer = new CheckedButtonsToolStripRenderer();
    //ActionGoToBookmarkMain.Click += GoToBookmark;
    SystemEvents.SessionEnding += SessionEnding;
    NativeMethods.ClipboardViewerNext = NativeMethods.SetClipboardViewer(Handle);
    HebrewGlobals.GetHebrewLettersExecutablePath = () => Settings.HebrewLettersExe;
    InitializeTheme();
    foreach ( var value in Enums.GetValues<PiDecimals>() )
      SelectFileName.Items.Add(value);
    SelectFileName.SelectedIndex = 2;
    ClearStatusBar();
    if ( !ApplicationCommandLine.Instance.IsPreviewEnabled ) // TODO remove when ready
    {
    }
  }

  /// <summary>
  /// Does Form Load event.
  /// </summary>
  private void DoFormLoad(object sender, EventArgs e)
  {
    if ( Globals.IsExiting ) return;
    Settings.Retrieve();
    //PreviousWindowsState = WindowState; // TODO move in settings helper and update calendar & letters
    Program.UpdateLocalization();
    StatisticsForm.Run(true, Settings.UsageStatisticsEnabled);
    Globals.ChronoStartingApp.Stop();
    // TODO uncomment
    //var lastdone = Settings.CheckUpdateLastDone;
    //bool exit = WebCheckUpdate.Run(ref lastdone,
    //                               Settings.CheckUpdateAtStartupDaysInterval,
    //                               Settings.CheckUpdateAtStartup,
    //                               true);
    //Settings.CheckUpdateLastDone = lastdone;
    //if ( exit )
    //{
    //  SystemManager.Exit();
    //  return;
    //}
    Globals.ChronoStartingApp.Start();
    //MainForm_ResizeEnd(null, null);
    //MainForm_Resize(null, null);
    BookmarkMenuIndex = ActionBookmarks.DropDownItems.Count;
    HistoryIndexMenu = ActionHistory.DropDownItems.Count;
    DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
  }

  /// <summary>
  /// Does Form Shown event.
  /// </summary>
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  private void DoFormShown(object sender, EventArgs e)
  {
    if ( Globals.IsExiting ) return;
    this.InitDropDowns();
    Refresh();
    //DoBackupDB();
    //LoadData();
    SetView(Settings.CurrentView, true);
    Globals.IsReady = true;
    Globals.KeyboardShortcutsNotice = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                           AppTranslations.NoticeKeyboardShortcuts,
                                                           true, false,
                                                           MessageBoxEx.DefaultHeightBig,
                                                           MessageBoxEx.DefaultHeightHuge,
                                                           false, false);
    Globals.KeyboardShortcutsNotice.TextBox.BackColor = Globals.KeyboardShortcutsNotice.BackColor;
    Globals.KeyboardShortcutsNotice.TextBox.BorderStyle = BorderStyle.None;
    Globals.KeyboardShortcutsNotice.Padding = new Padding(20, 20, 10, 10);
    Globals.ChronoStartingApp.Stop();
    Settings.BenchmarkStartingApp = Globals.ChronoStartingApp.ElapsedMilliseconds;
    SystemManager.TryCatch(Settings.Save);
    SystemManager.TryCatchManage(ProcessNewsAndCommandLine);
    Settings.SetFirstAndUpgradeFlagsOff();
  }

  /// <summary>
  /// Shows news and process command line options.
  /// </summary>
  private void ProcessNewsAndCommandLine()
  {
    if ( Globals.IsSettingsUpgraded && Settings.ShowLastNewInVersionAfterUpdate )
    {
      SystemManager.TryCatch(CommonMenusControl.Instance.ShowLastNews);
      Application.DoEvents();
      Thread.Sleep(500);
    }
    if ( SystemManager.CommandLineOptions is not null )
      try
      {
        var options = ApplicationCommandLine.Instance;
      }
      catch
      {
      }
  }

  /// <summary>
  /// Does Form Closing event.
  /// </summary>
  private void DoFormClosing(object sender, FormClosingEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( Globals.IsExiting ) return;
    if ( Globals.IsSessionEnding ) return;
    if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing )
      Globals.IsExiting = true;
    else
    if ( !Globals.AllowClose )
    {
      DisplayManager.ShowWarning(SysTranslations.CantExitWhileProcessing.GetLang());
      e.Cancel = true;
      return;
    }
    else
    if ( EditConfirmClosing.Checked )
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToExitApplication.GetLang()) )
        e.Cancel = true;
      else
        Globals.IsExiting = true;
  }

  /// <summary>
  /// Does Form Closed event.
  /// </summary>
  private void DoFormClosed(object sender, FormClosedEventArgs e)
  {
    DebugManager.Trace(LogTraceEvent.Data, e.CloseReason.ToStringFull());
    SystemManager.TryCatch(Settings.Store);
    Globals.AllowClose = true;
    Globals.IsExiting = true;
    Interlocks.Release();
    DebugManager.Stop();
    FormsHelper.CloseAll();
  }

  /// <summary>
  /// Does Session Ending event.
  /// </summary>
  private void SessionEnding(object sender, SessionEndingEventArgs e)
  {
    if ( Globals.IsExiting ) return;
    if ( Globals.IsSessionEnding ) return;
    DebugManager.Trace(LogTraceEvent.Data, e?.Reason.ToStringFull() ?? nameof(NativeMethods.WM_QUERYENDSESSION));
    Globals.AllowClose = true;
    Globals.IsSessionEnding = true;
    Close();
  }

  /// <summary>
  /// WndProc override.
  /// </summary>
  [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "N/A")]
  protected override void WndProc(ref Message m)
  {
    switch ( m.Msg )
    {
      case NativeMethods.WM_QUERYENDSESSION:
        SessionEnding(this, null);
        break;
      default:
        base.WndProc(ref m);
        break;
    }
  }

  /// <summary>
  /// Sets the initial directories of dialog boxes.
  /// </summary>
  public void InitializeDialogsDirectory()
  {
    //OpenFileDialogDB.InitialDirectory = Settings.GetBackupDirectory();
    //SaveFileDialogDB.InitialDirectory = Settings.GetBackupDirectory();
    //SaveDataBoardDialog.InitialDirectory = Settings.GetExportBoardsDirectory();
    //SaveFileDialogMSWord.InitialDirectory = Settings.GetExportVersesDirectory();
    //SaveFileDialogRTF.InitialDirectory = Settings.GetExportVersesDirectory();
    //SaveDataBoardDialog.Filter = Program.BoardExportTargets.CreateFilters();
  }

  /// <summary>
  /// Initializes icons
  /// </summary>
  private void InitializeIconsAndSound()
  {
    SoundItem.Initialize();
    SystemManager.TryCatch(() => DisplayManager.DoSound(Globals.EmptySoundFilePath));
    SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Globals.ProcessId, Settings.ApplicationVolume));
  }

  /// <summary>
  /// Sets colors.
  /// </summary>
  internal void InitializeTheme()
  {
    //// Navigator items
    //EditBookTranslation.BackColor = Settings.ThemeNavigatorItems;
    //EditChapterTitle.BackColor = Settings.ThemeNavigatorItems;
    //EditELS50Single.BackColor = Settings.ThemeNavigatorItems;
    //EditChapterMemo.BackColor = Settings.ThemeNavigatorItems;
    //EditVerseConcept.BackColor = Settings.ThemeNavigatorItems;
    //EditVerseTitle.BackColor = Settings.ThemeNavigatorItems;
    //// Letters control
    //EditSearchWord.LettersBackColor = Settings.ThemeSearchLettersBack;
    //EditSearchWord.InputBackColor = Settings.ThemeSearchWordBack;
    //EditSearchTranslation.BackColor = Settings.ThemeSearchWordBack;
    ////
    //ActionRefresh.PerformClick();
  }

}
