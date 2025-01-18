namespace Ordisoftware.Hebrew.Pi
{
  partial class MainForm
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.PanelDatabase = new System.Windows.Forms.Panel();
      this.SelectDbCache = new System.Windows.Forms.ComboBox();
      this.SelectFileName = new System.Windows.Forms.ComboBox();
      this.ActionDbClose = new System.Windows.Forms.Button();
      this.ActionDbOpen = new System.Windows.Forms.Button();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.LabelStatusTimeBatch = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusSep1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusTimeSubBatch = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusSep2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusRemaining = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusSep3 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusSep4 = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusAction = new System.Windows.Forms.ToolStripStatusLabel();
      this.LabelStatusFreeMem = new System.Windows.Forms.ToolStripStatusLabel();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ActionExit = new System.Windows.Forms.ToolStripButton();
      this.ToolStripSeparatorExit = new System.Windows.Forms.ToolStripSeparator();
      this.ActionPreferences = new System.Windows.Forms.ToolStripButton();
      this.ActionBookmarks = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionAddBookmark = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSortBookmarks = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionClearBookmarks = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionGoToBookmarkMain = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorBookmarks = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionHistory = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionClearHistory = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorHistory = new System.Windows.Forms.ToolStripSeparator();
      this.ActionHistoryBack = new System.Windows.Forms.ToolStripButton();
      this.ActionHistoryNext = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionViewDecode = new System.Windows.Forms.ToolStripButton();
      this.ActionViewGrid = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionViewPopulate = new System.Windows.Forms.ToolStripButton();
      this.ActionViewNormalize = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionViewStatistics = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionRun = new System.Windows.Forms.ToolStripButton();
      this.ActionStop = new System.Windows.Forms.ToolStripButton();
      this.ActionPause = new System.Windows.Forms.ToolStripButton();
      this.ActionContinue = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionDatabase = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionDatabaseNew = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionDatabaseRestore = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionDatabaseBackup = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionVacuum = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionDatabaseSetCacheSize = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenFolderExport = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenFolderBackup = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenFolderDatabase = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTools = new System.Windows.Forms.ToolStripDropDownButton();
      this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowTranscriptionGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowGrammarGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewLetters = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenCalculator = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTakeScreenshotWindow = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionTakeScreenshotView = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionRefresh = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorImportConcordances = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWebLinks = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionInformation = new System.Windows.Forms.ToolStripDropDownButton();
      this.MainMenuSeparatorLeftButtons = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenNone = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionResetWinSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.Sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowKeyboardNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
      this.EditExportUseHebrewFontElseUnicodeChars = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
      this.EditShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.EditUseAdvancedDialogBoxes = new System.Windows.Forms.ToolStripMenuItem();
      this.EditSoundsEnabled = new System.Windows.Forms.ToolStripMenuItem();
      this.EditShowSuccessDialogs = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
      this.EditConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.PanelMainOuter = new System.Windows.Forms.Panel();
      this.PanelMainInner = new System.Windows.Forms.Panel();
      this.PanelMainCenter = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageDecode = new System.Windows.Forms.TabPage();
      this.PanelViewDecode = new System.Windows.Forms.Panel();
      this.TabPageGrid = new System.Windows.Forms.TabPage();
      this.PanelViewGrid = new System.Windows.Forms.Panel();
      this.TabPagePopulate = new System.Windows.Forms.TabPage();
      this.PanelViewPopulate = new System.Windows.Forms.Panel();
      this.TabPageNormalize = new System.Windows.Forms.TabPage();
      this.PanelViewNormalize = new System.Windows.Forms.Panel();
      this.GridIterations = new System.Windows.Forms.DataGridView();
      this.ColumnIteration = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnRepeatedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnMaxOccurences = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnRemainingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnElapsedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnElapsedAddition = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BindingSourceIterationRow = new System.Windows.Forms.BindingSource(this.components);
      this.TabPageStatistics = new System.Windows.Forms.TabPage();
      this.PanelViewStatistics = new System.Windows.Forms.Panel();
      this.PanelSepTop = new System.Windows.Forms.Panel();
      this.PanelTitle = new System.Windows.Forms.Panel();
      this.PanelTitleInner = new System.Windows.Forms.Panel();
      this.LabelTitleCenter = new System.Windows.Forms.Label();
      this.LabelTitleLeft = new System.Windows.Forms.Label();
      this.LabelTitleRight = new System.Windows.Forms.Label();
      this.PanelSearchFilters = new System.Windows.Forms.Panel();
      this.SelectSearchType = new System.Windows.Forms.TabControl();
      this.SelectSearchTypeVerses = new System.Windows.Forms.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.SelectSearchRequestAllPartiallyTranslated = new System.Windows.Forms.RadioButton();
      this.SelectSearchRequestAllFullyTranslated = new System.Windows.Forms.RadioButton();
      this.SelectSearchRequestAllUntranslated = new System.Windows.Forms.RadioButton();
      this.SelectSearchRequestAllTranslated = new System.Windows.Forms.RadioButton();
      this.SelectSearchTypeTranslation = new System.Windows.Forms.TabPage();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.SelectSearchTranslationOnlyTranslations = new System.Windows.Forms.RadioButton();
      this.SelectSearchTranslationIncludeComments = new System.Windows.Forms.RadioButton();
      this.SelectSearchTranslationOnlyComments = new System.Windows.Forms.RadioButton();
      this.LabelSearchTranslationHelp = new System.Windows.Forms.Label();
      this.SelectSearchTypeHebrew = new System.Windows.Forms.TabPage();
      this.PanelSearchTop = new System.Windows.Forms.Panel();
      this.PanelSearchFiltersRight = new System.Windows.Forms.Panel();
      this.ActionSearchClear = new System.Windows.Forms.Button();
      this.ActionSearchNavigateLast = new System.Windows.Forms.Button();
      this.ActionSearchNavigateNext = new System.Windows.Forms.Button();
      this.ActionSearchNavigatePrevious = new System.Windows.Forms.Button();
      this.ActionNavigateSearchFirst = new System.Windows.Forms.Button();
      this.ActionSearchRun = new System.Windows.Forms.Button();
      this.EditSearchInTorah = new System.Windows.Forms.CheckBox();
      this.EditSearchInNeviim = new System.Windows.Forms.CheckBox();
      this.EditSearchInKetouvim = new System.Windows.Forms.CheckBox();
      this.SelectSearchPaging = new System.Windows.Forms.TrackBar();
      this.SelectSearchInBook = new System.Windows.Forms.ComboBox();
      this.ActionSearchInAddAll = new System.Windows.Forms.Button();
      this.ActionSearchInRemoveAll = new System.Windows.Forms.Button();
      this.ActionSearchWordOpenInLetters = new System.Windows.Forms.Button();
      this.PanelViewSearchSeparator = new System.Windows.Forms.Panel();
      this.PanelSearchResultsOuter = new System.Windows.Forms.Panel();
      this.PanelSearchResults = new System.Windows.Forms.Panel();
      this.TimerBatch = new System.Windows.Forms.Timer(this.components);
      this.TimerMemory = new System.Windows.Forms.Timer(this.components);
      this.TimerTooltip = new System.Windows.Forms.Timer(this.components);
      this.EditSearchTranslation = new Ordisoftware.Core.TextBoxEx();
      this.EditSearchWord = new Ordisoftware.Hebrew.LettersControl();
      this.EditSearchPaging = new Ordisoftware.Core.TextBoxEx();
      this.EditChapterOriginal = new Ordisoftware.Core.RichTextBoxEx();
      this.EditChapterELS50 = new Ordisoftware.Core.RichTextBoxEx();
      this.PanelDatabase.SuspendLayout();
      this.StatusStrip.SuspendLayout();
      this.ToolStrip.SuspendLayout();
      this.PanelMain.SuspendLayout();
      this.PanelMainOuter.SuspendLayout();
      this.PanelMainInner.SuspendLayout();
      this.PanelMainCenter.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.TabPageDecode.SuspendLayout();
      this.TabPageGrid.SuspendLayout();
      this.TabPagePopulate.SuspendLayout();
      this.TabPageNormalize.SuspendLayout();
      this.PanelViewNormalize.SuspendLayout();
      ( (System.ComponentModel.ISupportInitialize)( this.GridIterations ) ).BeginInit();
      ( (System.ComponentModel.ISupportInitialize)( this.BindingSourceIterationRow ) ).BeginInit();
      this.TabPageStatistics.SuspendLayout();
      this.PanelTitle.SuspendLayout();
      this.PanelTitleInner.SuspendLayout();
      ( (System.ComponentModel.ISupportInitialize)( this.SelectSearchPaging ) ).BeginInit();
      this.SuspendLayout();
      // 
      // PanelDatabase
      // 
      this.PanelDatabase.Controls.Add(this.SelectDbCache);
      this.PanelDatabase.Controls.Add(this.SelectFileName);
      this.PanelDatabase.Controls.Add(this.ActionDbClose);
      this.PanelDatabase.Controls.Add(this.ActionDbOpen);
      this.PanelDatabase.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelDatabase.Location = new System.Drawing.Point(10, 10);
      this.PanelDatabase.Name = "PanelDatabase";
      this.PanelDatabase.Size = new System.Drawing.Size(939, 40);
      this.PanelDatabase.TabIndex = 1;
      // 
      // SelectDbCache
      // 
      this.SelectDbCache.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectDbCache.FormattingEnabled = true;
      this.SelectDbCache.Location = new System.Drawing.Point(5, 3);
      this.SelectDbCache.Name = "SelectDbCache";
      this.SelectDbCache.Size = new System.Drawing.Size(50, 21);
      this.SelectDbCache.TabIndex = 3;
      this.SelectDbCache.SelectedIndexChanged += new System.EventHandler(this.SelectDbCache_SelectedIndexChanged);
      // 
      // SelectFileName
      // 
      this.SelectFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectFileName.FormattingEnabled = true;
      this.SelectFileName.Location = new System.Drawing.Point(61, 3);
      this.SelectFileName.Name = "SelectFileName";
      this.SelectFileName.Size = new System.Drawing.Size(121, 21);
      this.SelectFileName.TabIndex = 3;
      this.SelectFileName.SelectedIndexChanged += new System.EventHandler(this.SelectFileName_SelectedIndexChanged);
      // 
      // ActionDbClose
      // 
      this.ActionDbClose.Enabled = false;
      this.ActionDbClose.Location = new System.Drawing.Point(252, 2);
      this.ActionDbClose.Name = "ActionDbClose";
      this.ActionDbClose.Size = new System.Drawing.Size(58, 23);
      this.ActionDbClose.TabIndex = 2;
      this.ActionDbClose.Text = "Close";
      this.ActionDbClose.UseVisualStyleBackColor = true;
      this.ActionDbClose.Click += new System.EventHandler(this.ActionDbClose_Click);
      // 
      // ActionDbOpen
      // 
      this.ActionDbOpen.Enabled = false;
      this.ActionDbOpen.Location = new System.Drawing.Point(188, 2);
      this.ActionDbOpen.Name = "ActionDbOpen";
      this.ActionDbOpen.Size = new System.Drawing.Size(58, 23);
      this.ActionDbOpen.TabIndex = 2;
      this.ActionDbOpen.Text = "Open";
      this.ActionDbOpen.UseVisualStyleBackColor = true;
      this.ActionDbOpen.Click += new System.EventHandler(this.ActionDbOpen_Click);
      // 
      // StatusStrip
      // 
      this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatusTimeBatch,
            this.LabelStatusSep1,
            this.LabelStatusTimeSubBatch,
            this.LabelStatusSep2,
            this.LabelStatusRemaining,
            this.LabelStatusSep3,
            this.LabelStatusInfo,
            this.LabelStatusSep4,
            this.LabelStatusAction,
            this.LabelStatusFreeMem});
      this.StatusStrip.Location = new System.Drawing.Point(0, 539);
      this.StatusStrip.Name = "StatusStrip";
      this.StatusStrip.Size = new System.Drawing.Size(959, 22);
      this.StatusStrip.TabIndex = 2;
      this.StatusStrip.Text = "statusStrip1";
      // 
      // LabelStatusTimeBatch
      // 
      this.LabelStatusTimeBatch.Name = "LabelStatusTimeBatch";
      this.LabelStatusTimeBatch.Size = new System.Drawing.Size(60, 17);
      this.LabelStatusTimeBatch.Text = "Batch: 00s";
      // 
      // LabelStatusSep1
      // 
      this.LabelStatusSep1.Name = "LabelStatusSep1";
      this.LabelStatusSep1.Size = new System.Drawing.Size(10, 17);
      this.LabelStatusSep1.Text = "|";
      // 
      // LabelStatusTimeSubBatch
      // 
      this.LabelStatusTimeSubBatch.Name = "LabelStatusTimeSubBatch";
      this.LabelStatusTimeSubBatch.Size = new System.Drawing.Size(80, 17);
      this.LabelStatusTimeSubBatch.Text = "SubBatch: 00s";
      // 
      // LabelStatusSep2
      // 
      this.LabelStatusSep2.Name = "LabelStatusSep2";
      this.LabelStatusSep2.Size = new System.Drawing.Size(10, 17);
      this.LabelStatusSep2.Text = "|";
      // 
      // LabelStatusRemaining
      // 
      this.LabelStatusRemaining.Name = "LabelStatusRemaining";
      this.LabelStatusRemaining.Size = new System.Drawing.Size(90, 17);
      this.LabelStatusRemaining.Text = "Remaining:  00s";
      // 
      // LabelStatusSep3
      // 
      this.LabelStatusSep3.Name = "LabelStatusSep3";
      this.LabelStatusSep3.Size = new System.Drawing.Size(10, 17);
      this.LabelStatusSep3.Text = "|";
      // 
      // LabelStatusInfo
      // 
      this.LabelStatusInfo.Name = "LabelStatusInfo";
      this.LabelStatusInfo.Size = new System.Drawing.Size(28, 17);
      this.LabelStatusInfo.Text = "Info";
      // 
      // LabelStatusSep4
      // 
      this.LabelStatusSep4.Name = "LabelStatusSep4";
      this.LabelStatusSep4.Size = new System.Drawing.Size(10, 17);
      this.LabelStatusSep4.Text = "|";
      // 
      // LabelStatusAction
      // 
      this.LabelStatusAction.Name = "LabelStatusAction";
      this.LabelStatusAction.Size = new System.Drawing.Size(42, 17);
      this.LabelStatusAction.Text = "Action";
      // 
      // LabelStatusFreeMem
      // 
      this.LabelStatusFreeMem.Name = "LabelStatusFreeMem";
      this.LabelStatusFreeMem.Size = new System.Drawing.Size(604, 17);
      this.LabelStatusFreeMem.Spring = true;
      this.LabelStatusFreeMem.Text = "Free mem";
      this.LabelStatusFreeMem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // ToolStrip
      // 
      this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionExit,
            this.ToolStripSeparatorExit,
            this.ActionPreferences,
            this.ActionBookmarks,
            this.toolStripSeparator13,
            this.ActionHistory,
            this.ActionHistoryBack,
            this.ActionHistoryNext,
            this.toolStripSeparator19,
            this.ActionViewDecode,
            this.ActionViewGrid,
            this.toolStripSeparator9,
            this.ActionViewPopulate,
            this.ActionViewNormalize,
            this.toolStripSeparator10,
            this.ActionViewStatistics,
            this.toolStripSeparator5,
            this.ActionRun,
            this.ActionStop,
            this.ActionPause,
            this.ActionContinue,
            this.toolStripSeparator8,
            this.ActionDatabase,
            this.toolStripSeparator20,
            this.ActionTools,
            this.ActionWebLinks,
            this.ActionInformation,
            this.MainMenuSeparatorLeftButtons,
            this.ActionSettings});
      this.ToolStrip.Location = new System.Drawing.Point(0, 0);
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
      this.ToolStrip.ShowItemToolTips = false;
      this.ToolStrip.Size = new System.Drawing.Size(959, 54);
      this.ToolStrip.TabIndex = 4;
      // 
      // ActionExit
      // 
      this.ActionExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionExit.Image = ( (System.Drawing.Image)( resources.GetObject("ActionExit.Image") ) );
      this.ActionExit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionExit.Name = "ActionExit";
      this.ActionExit.Padding = new System.Windows.Forms.Padding(4);
      this.ActionExit.Size = new System.Drawing.Size(44, 46);
      this.ActionExit.Text = "Exit";
      this.ActionExit.ToolTipText = "Exit";
      this.ActionExit.Click += new System.EventHandler(this.ActionExit_Click);
      this.ActionExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ActionExit_MouseUp);
      // 
      // ToolStripSeparatorExit
      // 
      this.ToolStripSeparatorExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ToolStripSeparatorExit.Name = "ToolStripSeparatorExit";
      this.ToolStripSeparatorExit.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionPreferences
      // 
      this.ActionPreferences.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionPreferences.Image = ( (System.Drawing.Image)( resources.GetObject("ActionPreferences.Image") ) );
      this.ActionPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionPreferences.Name = "ActionPreferences";
      this.ActionPreferences.Padding = new System.Windows.Forms.Padding(4);
      this.ActionPreferences.Size = new System.Drawing.Size(44, 46);
      this.ActionPreferences.Text = "Preferences";
      this.ActionPreferences.ToolTipText = "Preferences (F9)";
      this.ActionPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      // 
      // ActionBookmarks
      // 
      this.ActionBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionBookmarks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionAddBookmark,
            this.toolStripSeparator3,
            this.ActionSortBookmarks,
            this.toolStripSeparator7,
            this.ActionClearBookmarks,
            this.toolStripSeparator4,
            this.ActionGoToBookmarkMain,
            this.SeparatorBookmarks});
      this.ActionBookmarks.Image = ( (System.Drawing.Image)( resources.GetObject("ActionBookmarks.Image") ) );
      this.ActionBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionBookmarks.Name = "ActionBookmarks";
      this.ActionBookmarks.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.ActionBookmarks.Size = new System.Drawing.Size(49, 46);
      this.ActionBookmarks.Text = "Bookmarks";
      this.ActionBookmarks.ToolTipText = "Bookmarks (Alt+B)";
      // 
      // ActionAddBookmark
      // 
      this.ActionAddBookmark.Image = ( (System.Drawing.Image)( resources.GetObject("ActionAddBookmark.Image") ) );
      this.ActionAddBookmark.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionAddBookmark.Name = "ActionAddBookmark";
      this.ActionAddBookmark.Size = new System.Drawing.Size(108, 22);
      this.ActionAddBookmark.Text = "Add";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(105, 6);
      // 
      // ActionSortBookmarks
      // 
      this.ActionSortBookmarks.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSortBookmarks.Image") ) );
      this.ActionSortBookmarks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionSortBookmarks.Name = "ActionSortBookmarks";
      this.ActionSortBookmarks.Size = new System.Drawing.Size(108, 22);
      this.ActionSortBookmarks.Text = "Sort";
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(105, 6);
      // 
      // ActionClearBookmarks
      // 
      this.ActionClearBookmarks.Image = ( (System.Drawing.Image)( resources.GetObject("ActionClearBookmarks.Image") ) );
      this.ActionClearBookmarks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionClearBookmarks.Name = "ActionClearBookmarks";
      this.ActionClearBookmarks.Size = new System.Drawing.Size(108, 22);
      this.ActionClearBookmarks.Text = "Empty";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(105, 6);
      // 
      // ActionGoToBookmarkMain
      // 
      this.ActionGoToBookmarkMain.Image = ( (System.Drawing.Image)( resources.GetObject("ActionGoToBookmarkMain.Image") ) );
      this.ActionGoToBookmarkMain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionGoToBookmarkMain.Name = "ActionGoToBookmarkMain";
      this.ActionGoToBookmarkMain.Size = new System.Drawing.Size(108, 22);
      this.ActionGoToBookmarkMain.Text = "Main";
      // 
      // SeparatorBookmarks
      // 
      this.SeparatorBookmarks.Name = "SeparatorBookmarks";
      this.SeparatorBookmarks.Size = new System.Drawing.Size(105, 6);
      // 
      // toolStripSeparator13
      // 
      this.toolStripSeparator13.Name = "toolStripSeparator13";
      this.toolStripSeparator13.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionHistory
      // 
      this.ActionHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionClearHistory,
            this.SeparatorHistory});
      this.ActionHistory.Image = ( (System.Drawing.Image)( resources.GetObject("ActionHistory.Image") ) );
      this.ActionHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionHistory.Name = "ActionHistory";
      this.ActionHistory.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.ActionHistory.Size = new System.Drawing.Size(49, 46);
      this.ActionHistory.Text = "History";
      this.ActionHistory.ToolTipText = "History (Alt+H)";
      // 
      // ActionClearHistory
      // 
      this.ActionClearHistory.Image = ( (System.Drawing.Image)( resources.GetObject("ActionClearHistory.Image") ) );
      this.ActionClearHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionClearHistory.Name = "ActionClearHistory";
      this.ActionClearHistory.Size = new System.Drawing.Size(108, 22);
      this.ActionClearHistory.Text = "Empty";
      // 
      // SeparatorHistory
      // 
      this.SeparatorHistory.Name = "SeparatorHistory";
      this.SeparatorHistory.Size = new System.Drawing.Size(105, 6);
      // 
      // ActionHistoryBack
      // 
      this.ActionHistoryBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionHistoryBack.Image = ( (System.Drawing.Image)( resources.GetObject("ActionHistoryBack.Image") ) );
      this.ActionHistoryBack.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionHistoryBack.Name = "ActionHistoryBack";
      this.ActionHistoryBack.Padding = new System.Windows.Forms.Padding(4);
      this.ActionHistoryBack.Size = new System.Drawing.Size(44, 46);
      this.ActionHistoryBack.Text = "Previous";
      this.ActionHistoryBack.ToolTipText = "Previous (Shift+Ctrl+P)";
      // 
      // ActionHistoryNext
      // 
      this.ActionHistoryNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionHistoryNext.Image = ( (System.Drawing.Image)( resources.GetObject("ActionHistoryNext.Image") ) );
      this.ActionHistoryNext.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionHistoryNext.Name = "ActionHistoryNext";
      this.ActionHistoryNext.Padding = new System.Windows.Forms.Padding(4);
      this.ActionHistoryNext.Size = new System.Drawing.Size(44, 46);
      this.ActionHistoryNext.Text = "Next";
      this.ActionHistoryNext.ToolTipText = "Next (Shift+Ctrl+N)";
      // 
      // toolStripSeparator19
      // 
      this.toolStripSeparator19.Name = "toolStripSeparator19";
      this.toolStripSeparator19.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionViewDecode
      // 
      this.ActionViewDecode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionViewDecode.Image = ( (System.Drawing.Image)( resources.GetObject("ActionViewDecode.Image") ) );
      this.ActionViewDecode.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionViewDecode.Name = "ActionViewDecode";
      this.ActionViewDecode.Padding = new System.Windows.Forms.Padding(4);
      this.ActionViewDecode.Size = new System.Drawing.Size(44, 46);
      this.ActionViewDecode.Text = "Decode and translate";
      this.ActionViewDecode.ToolTipText = "Decode and translate (F1)";
      this.ActionViewDecode.Click += new System.EventHandler(this.ActionViewDecode_Click);
      // 
      // ActionViewGrid
      // 
      this.ActionViewGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionViewGrid.Image = ( (System.Drawing.Image)( resources.GetObject("ActionViewGrid.Image") ) );
      this.ActionViewGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionViewGrid.Name = "ActionViewGrid";
      this.ActionViewGrid.Padding = new System.Windows.Forms.Padding(4);
      this.ActionViewGrid.Size = new System.Drawing.Size(44, 46);
      this.ActionViewGrid.Text = "View data grid";
      this.ActionViewGrid.ToolTipText = "View data grid (F2)";
      this.ActionViewGrid.Click += new System.EventHandler(this.ActionViewGrid_Click);
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionViewPopulate
      // 
      this.ActionViewPopulate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionViewPopulate.Image = ( (System.Drawing.Image)( resources.GetObject("ActionViewPopulate.Image") ) );
      this.ActionViewPopulate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionViewPopulate.Name = "ActionViewPopulate";
      this.ActionViewPopulate.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewPopulate.Size = new System.Drawing.Size(46, 46);
      this.ActionViewPopulate.Text = "Create data from file ";
      this.ActionViewPopulate.ToolTipText = "Create data from file (F3)";
      this.ActionViewPopulate.Click += new System.EventHandler(this.ActionViewPopulate_Click);
      // 
      // ActionViewNormalize
      // 
      this.ActionViewNormalize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionViewNormalize.Image = ( (System.Drawing.Image)( resources.GetObject("ActionViewNormalize.Image") ) );
      this.ActionViewNormalize.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionViewNormalize.Name = "ActionViewNormalize";
      this.ActionViewNormalize.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewNormalize.Size = new System.Drawing.Size(46, 46);
      this.ActionViewNormalize.Text = "Reduce repeating motifs";
      this.ActionViewNormalize.ToolTipText = "Reduce repeating motifs (F4)";
      this.ActionViewNormalize.Click += new System.EventHandler(this.ActionViewNormalize_Click);
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionViewStatistics
      // 
      this.ActionViewStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionViewStatistics.Image = ( (System.Drawing.Image)( resources.GetObject("ActionViewStatistics.Image") ) );
      this.ActionViewStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionViewStatistics.Name = "ActionViewStatistics";
      this.ActionViewStatistics.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewStatistics.Size = new System.Drawing.Size(46, 46);
      this.ActionViewStatistics.Text = "Statistics";
      this.ActionViewStatistics.ToolTipText = "Statistics (F5)";
      this.ActionViewStatistics.Click += new System.EventHandler(this.ActionViewStatistics_Click);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionRun
      // 
      this.ActionRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionRun.Image = ( (System.Drawing.Image)( resources.GetObject("ActionRun.Image") ) );
      this.ActionRun.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionRun.Name = "ActionRun";
      this.ActionRun.Padding = new System.Windows.Forms.Padding(4);
      this.ActionRun.Size = new System.Drawing.Size(44, 46);
      this.ActionRun.Text = "Run";
      this.ActionRun.ToolTipText = "Run (F5)";
      this.ActionRun.Click += new System.EventHandler(this.ActionRun_Click);
      // 
      // ActionStop
      // 
      this.ActionStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionStop.Enabled = false;
      this.ActionStop.Image = ( (System.Drawing.Image)( resources.GetObject("ActionStop.Image") ) );
      this.ActionStop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionStop.Name = "ActionStop";
      this.ActionStop.Padding = new System.Windows.Forms.Padding(5);
      this.ActionStop.Size = new System.Drawing.Size(46, 46);
      this.ActionStop.Text = "Pause";
      this.ActionStop.ToolTipText = "Pause";
      this.ActionStop.Click += new System.EventHandler(this.ActionStop_Click);
      // 
      // ActionPause
      // 
      this.ActionPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionPause.Enabled = false;
      this.ActionPause.Image = ( (System.Drawing.Image)( resources.GetObject("ActionPause.Image") ) );
      this.ActionPause.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionPause.Name = "ActionPause";
      this.ActionPause.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPause.Size = new System.Drawing.Size(46, 46);
      this.ActionPause.Text = "Pause";
      this.ActionPause.ToolTipText = "Pause";
      this.ActionPause.Click += new System.EventHandler(this.ActionPauseContinue_Click);
      // 
      // ActionContinue
      // 
      this.ActionContinue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionContinue.Enabled = false;
      this.ActionContinue.Image = ( (System.Drawing.Image)( resources.GetObject("ActionContinue.Image") ) );
      this.ActionContinue.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionContinue.Name = "ActionContinue";
      this.ActionContinue.Padding = new System.Windows.Forms.Padding(5);
      this.ActionContinue.Size = new System.Drawing.Size(46, 46);
      this.ActionContinue.Text = "Continue";
      this.ActionContinue.ToolTipText = "Continue";
      this.ActionContinue.Visible = false;
      this.ActionContinue.Click += new System.EventHandler(this.ActionPauseContinue_Click);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionDatabase
      // 
      this.ActionDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionDatabaseNew,
            this.ActionDatabaseRestore,
            this.ActionDatabaseBackup,
            this.toolStripSeparator22,
            this.ActionVacuum,
            this.ActionDatabaseSetCacheSize,
            this.toolStripSeparator2,
            this.ActionOpenFolderExport,
            this.ActionOpenFolderBackup,
            this.ActionOpenFolderDatabase});
      this.ActionDatabase.Image = ( (System.Drawing.Image)( resources.GetObject("ActionDatabase.Image") ) );
      this.ActionDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionDatabase.Name = "ActionDatabase";
      this.ActionDatabase.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.ActionDatabase.Size = new System.Drawing.Size(49, 46);
      // 
      // ActionDatabaseNew
      // 
      this.ActionDatabaseNew.Image = ( (System.Drawing.Image)( resources.GetObject("ActionDatabaseNew.Image") ) );
      this.ActionDatabaseNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionDatabaseNew.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionDatabaseNew.Name = "ActionDatabaseNew";
      this.ActionDatabaseNew.Size = new System.Drawing.Size(210, 22);
      this.ActionDatabaseNew.Text = "New database";
      // 
      // ActionDatabaseRestore
      // 
      this.ActionDatabaseRestore.Image = ( (System.Drawing.Image)( resources.GetObject("ActionDatabaseRestore.Image") ) );
      this.ActionDatabaseRestore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionDatabaseRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionDatabaseRestore.Name = "ActionDatabaseRestore";
      this.ActionDatabaseRestore.Size = new System.Drawing.Size(210, 22);
      this.ActionDatabaseRestore.Text = "Restore database";
      // 
      // ActionDatabaseBackup
      // 
      this.ActionDatabaseBackup.Image = ( (System.Drawing.Image)( resources.GetObject("ActionDatabaseBackup.Image") ) );
      this.ActionDatabaseBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionDatabaseBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionDatabaseBackup.Name = "ActionDatabaseBackup";
      this.ActionDatabaseBackup.Size = new System.Drawing.Size(210, 22);
      this.ActionDatabaseBackup.Text = "Backup database";
      // 
      // toolStripSeparator22
      // 
      this.toolStripSeparator22.Name = "toolStripSeparator22";
      this.toolStripSeparator22.Size = new System.Drawing.Size(207, 6);
      // 
      // ActionVacuum
      // 
      this.ActionVacuum.Image = ( (System.Drawing.Image)( resources.GetObject("ActionVacuum.Image") ) );
      this.ActionVacuum.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionVacuum.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionVacuum.Name = "ActionVacuum";
      this.ActionVacuum.Size = new System.Drawing.Size(210, 22);
      this.ActionVacuum.Text = "Optimize database";
      // 
      // ActionDatabaseSetCacheSize
      // 
      this.ActionDatabaseSetCacheSize.Image = ( (System.Drawing.Image)( resources.GetObject("ActionDatabaseSetCacheSize.Image") ) );
      this.ActionDatabaseSetCacheSize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionDatabaseSetCacheSize.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionDatabaseSetCacheSize.Name = "ActionDatabaseSetCacheSize";
      this.ActionDatabaseSetCacheSize.Size = new System.Drawing.Size(210, 22);
      this.ActionDatabaseSetCacheSize.Text = "Set SQLite cache size";
      this.ActionDatabaseSetCacheSize.Click += new System.EventHandler(this.ActionDatabaseSetCacheSize_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
      // 
      // ActionOpenFolderExport
      // 
      this.ActionOpenFolderExport.Image = ( (System.Drawing.Image)( resources.GetObject("ActionOpenFolderExport.Image") ) );
      this.ActionOpenFolderExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionOpenFolderExport.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionOpenFolderExport.Name = "ActionOpenFolderExport";
      this.ActionOpenFolderExport.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E ) ) );
      this.ActionOpenFolderExport.Size = new System.Drawing.Size(210, 22);
      this.ActionOpenFolderExport.Text = "Open export folder";
      // 
      // ActionOpenFolderBackup
      // 
      this.ActionOpenFolderBackup.Image = ( (System.Drawing.Image)( resources.GetObject("ActionOpenFolderBackup.Image") ) );
      this.ActionOpenFolderBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionOpenFolderBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionOpenFolderBackup.Name = "ActionOpenFolderBackup";
      this.ActionOpenFolderBackup.Size = new System.Drawing.Size(210, 22);
      this.ActionOpenFolderBackup.Text = "Open archive folder";
      // 
      // ActionOpenFolderDatabase
      // 
      this.ActionOpenFolderDatabase.Image = ( (System.Drawing.Image)( resources.GetObject("ActionOpenFolderDatabase.Image") ) );
      this.ActionOpenFolderDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionOpenFolderDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionOpenFolderDatabase.Name = "ActionOpenFolderDatabase";
      this.ActionOpenFolderDatabase.Size = new System.Drawing.Size(210, 22);
      this.ActionOpenFolderDatabase.Text = "Open database folder";
      // 
      // toolStripSeparator20
      // 
      this.toolStripSeparator20.Name = "toolStripSeparator20";
      this.toolStripSeparator20.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
      this.toolStripSeparator20.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionTools
      // 
      this.ActionTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator28,
            this.ActionShowTranscriptionGuide,
            this.ActionShowGrammarGuide,
            this.toolStripSeparator6,
            this.ActionOpenHebrewLetters,
            this.ActionOpenCalculator,
            this.toolStripSeparator29,
            this.ActionTakeScreenshotWindow,
            this.ActionTakeScreenshotView,
            this.toolStripSeparator1,
            this.ActionCopyToClipboard,
            this.ActionRefresh,
            this.SeparatorImportConcordances});
      this.ActionTools.Image = ( (System.Drawing.Image)( resources.GetObject("ActionTools.Image") ) );
      this.ActionTools.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionTools.Name = "ActionTools";
      this.ActionTools.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.ActionTools.Size = new System.Drawing.Size(49, 46);
      // 
      // toolStripSeparator28
      // 
      this.toolStripSeparator28.Name = "toolStripSeparator28";
      this.toolStripSeparator28.Size = new System.Drawing.Size(260, 6);
      // 
      // ActionShowTranscriptionGuide
      // 
      this.ActionShowTranscriptionGuide.Image = ( (System.Drawing.Image)( resources.GetObject("ActionShowTranscriptionGuide.Image") ) );
      this.ActionShowTranscriptionGuide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionShowTranscriptionGuide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionShowTranscriptionGuide.Name = "ActionShowTranscriptionGuide";
      this.ActionShowTranscriptionGuide.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L ) ) );
      this.ActionShowTranscriptionGuide.Size = new System.Drawing.Size(263, 22);
      this.ActionShowTranscriptionGuide.Text = "Transcription guide";
      // 
      // ActionShowGrammarGuide
      // 
      this.ActionShowGrammarGuide.Image = ( (System.Drawing.Image)( resources.GetObject("ActionShowGrammarGuide.Image") ) );
      this.ActionShowGrammarGuide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionShowGrammarGuide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionShowGrammarGuide.Name = "ActionShowGrammarGuide";
      this.ActionShowGrammarGuide.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G ) ) );
      this.ActionShowGrammarGuide.Size = new System.Drawing.Size(263, 22);
      this.ActionShowGrammarGuide.Text = "Grammar guide";
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(260, 6);
      // 
      // ActionOpenHebrewLetters
      // 
      this.ActionOpenHebrewLetters.Image = ( (System.Drawing.Image)( resources.GetObject("ActionOpenHebrewLetters.Image") ) );
      this.ActionOpenHebrewLetters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionOpenHebrewLetters.Name = "ActionOpenHebrewLetters";
      this.ActionOpenHebrewLetters.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H ) ) );
      this.ActionOpenHebrewLetters.Size = new System.Drawing.Size(263, 22);
      this.ActionOpenHebrewLetters.Text = "Hebrew Letters";
      // 
      // ActionOpenCalculator
      // 
      this.ActionOpenCalculator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionOpenCalculator.Image = ( (System.Drawing.Image)( resources.GetObject("ActionOpenCalculator.Image") ) );
      this.ActionOpenCalculator.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionOpenCalculator.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionOpenCalculator.Name = "ActionOpenCalculator";
      this.ActionOpenCalculator.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C ) ) );
      this.ActionOpenCalculator.Size = new System.Drawing.Size(263, 22);
      this.ActionOpenCalculator.Text = "Calculator";
      // 
      // toolStripSeparator29
      // 
      this.toolStripSeparator29.Name = "toolStripSeparator29";
      this.toolStripSeparator29.Size = new System.Drawing.Size(260, 6);
      // 
      // ActionTakeScreenshotWindow
      // 
      this.ActionTakeScreenshotWindow.Image = ( (System.Drawing.Image)( resources.GetObject("ActionTakeScreenshotWindow.Image") ) );
      this.ActionTakeScreenshotWindow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionTakeScreenshotWindow.Name = "ActionTakeScreenshotWindow";
      this.ActionTakeScreenshotWindow.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F12 ) ) );
      this.ActionTakeScreenshotWindow.Size = new System.Drawing.Size(263, 22);
      this.ActionTakeScreenshotWindow.Text = "Screenshot of the window";
      // 
      // ActionTakeScreenshotView
      // 
      this.ActionTakeScreenshotView.Image = ( (System.Drawing.Image)( resources.GetObject("ActionTakeScreenshotView.Image") ) );
      this.ActionTakeScreenshotView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionTakeScreenshotView.Name = "ActionTakeScreenshotView";
      this.ActionTakeScreenshotView.ShortcutKeyDisplayString = "Shift + F12";
      this.ActionTakeScreenshotView.Size = new System.Drawing.Size(263, 22);
      this.ActionTakeScreenshotView.Text = "Screenshot of the view";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(260, 6);
      // 
      // ActionCopyToClipboard
      // 
      this.ActionCopyToClipboard.Image = ( (System.Drawing.Image)( resources.GetObject("ActionCopyToClipboard.Image") ) );
      this.ActionCopyToClipboard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionCopyToClipboard.Name = "ActionCopyToClipboard";
      this.ActionCopyToClipboard.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F8 ) ) );
      this.ActionCopyToClipboard.Size = new System.Drawing.Size(263, 22);
      this.ActionCopyToClipboard.Text = "Copy view";
      // 
      // ActionRefresh
      // 
      this.ActionRefresh.Image = ( (System.Drawing.Image)( resources.GetObject("ActionRefresh.Image") ) );
      this.ActionRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionRefresh.Name = "ActionRefresh";
      this.ActionRefresh.ShortcutKeys = System.Windows.Forms.Keys.F8;
      this.ActionRefresh.Size = new System.Drawing.Size(263, 22);
      this.ActionRefresh.Text = "Refresh view";
      // 
      // SeparatorImportConcordances
      // 
      this.SeparatorImportConcordances.Name = "SeparatorImportConcordances";
      this.SeparatorImportConcordances.Size = new System.Drawing.Size(260, 6);
      this.SeparatorImportConcordances.Visible = false;
      // 
      // ActionWebLinks
      // 
      this.ActionWebLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionWebLinks.Image = ( (System.Drawing.Image)( resources.GetObject("ActionWebLinks.Image") ) );
      this.ActionWebLinks.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionWebLinks.Name = "ActionWebLinks";
      this.ActionWebLinks.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.ActionWebLinks.Size = new System.Drawing.Size(49, 46);
      // 
      // ActionInformation
      // 
      this.ActionInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionInformation.Image = ( (System.Drawing.Image)( resources.GetObject("ActionInformation.Image") ) );
      this.ActionInformation.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionInformation.Name = "ActionInformation";
      this.ActionInformation.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.ActionInformation.Size = new System.Drawing.Size(49, 46);
      // 
      // MainMenuSeparatorLeftButtons
      // 
      this.MainMenuSeparatorLeftButtons.Name = "MainMenuSeparatorLeftButtons";
      this.MainMenuSeparatorLeftButtons.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
      this.MainMenuSeparatorLeftButtons.Size = new System.Drawing.Size(6, 49);
      // 
      // ActionSettings
      // 
      this.ActionSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionScreenPosition,
            this.ActionResetWinSettings,
            this.Sep7,
            this.ActionShowKeyboardNotice,
            this.toolStripSeparator27,
            this.EditExportUseHebrewFontElseUnicodeChars,
            this.toolStripSeparator11,
            this.EditShowTips,
            this.EditUseAdvancedDialogBoxes,
            this.EditSoundsEnabled,
            this.EditShowSuccessDialogs,
            this.toolStripSeparator15,
            this.EditConfirmClosing});
      this.ActionSettings.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSettings.Image") ) );
      this.ActionSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ActionSettings.Name = "ActionSettings";
      this.ActionSettings.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.ActionSettings.Size = new System.Drawing.Size(49, 46);
      // 
      // ActionScreenPosition
      // 
      this.ActionScreenPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditScreenNone,
            this.EditScreenTopLeft,
            this.EditScreenTopRight,
            this.EditScreenBottomLeft,
            this.EditScreenBottomRight,
            this.EditScreenCenter});
      this.ActionScreenPosition.Image = ( (System.Drawing.Image)( resources.GetObject("ActionScreenPosition.Image") ) );
      this.ActionScreenPosition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionScreenPosition.Name = "ActionScreenPosition";
      this.ActionScreenPosition.Size = new System.Drawing.Size(323, 22);
      this.ActionScreenPosition.Text = "Screen position";
      // 
      // EditScreenNone
      // 
      this.EditScreenNone.CheckOnClick = true;
      this.EditScreenNone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditScreenNone.Name = "EditScreenNone";
      this.EditScreenNone.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0 ) ) );
      this.EditScreenNone.Size = new System.Drawing.Size(178, 22);
      this.EditScreenNone.Text = "Loose";
      this.EditScreenNone.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopLeft
      // 
      this.EditScreenTopLeft.CheckOnClick = true;
      this.EditScreenTopLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditScreenTopLeft.Name = "EditScreenTopLeft";
      this.EditScreenTopLeft.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1 ) ) );
      this.EditScreenTopLeft.Size = new System.Drawing.Size(178, 22);
      this.EditScreenTopLeft.Text = "Top left";
      this.EditScreenTopLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopRight
      // 
      this.EditScreenTopRight.CheckOnClick = true;
      this.EditScreenTopRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditScreenTopRight.Name = "EditScreenTopRight";
      this.EditScreenTopRight.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2 ) ) );
      this.EditScreenTopRight.Size = new System.Drawing.Size(178, 22);
      this.EditScreenTopRight.Text = "Top right";
      this.EditScreenTopRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomLeft
      // 
      this.EditScreenBottomLeft.CheckOnClick = true;
      this.EditScreenBottomLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditScreenBottomLeft.Name = "EditScreenBottomLeft";
      this.EditScreenBottomLeft.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3 ) ) );
      this.EditScreenBottomLeft.Size = new System.Drawing.Size(178, 22);
      this.EditScreenBottomLeft.Text = "Bottom left";
      this.EditScreenBottomLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomRight
      // 
      this.EditScreenBottomRight.CheckOnClick = true;
      this.EditScreenBottomRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditScreenBottomRight.Name = "EditScreenBottomRight";
      this.EditScreenBottomRight.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4 ) ) );
      this.EditScreenBottomRight.Size = new System.Drawing.Size(178, 22);
      this.EditScreenBottomRight.Text = "Bottom right";
      this.EditScreenBottomRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenCenter
      // 
      this.EditScreenCenter.CheckOnClick = true;
      this.EditScreenCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditScreenCenter.Name = "EditScreenCenter";
      this.EditScreenCenter.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5 ) ) );
      this.EditScreenCenter.Size = new System.Drawing.Size(178, 22);
      this.EditScreenCenter.Text = "Center";
      this.EditScreenCenter.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // ActionResetWinSettings
      // 
      this.ActionResetWinSettings.Image = ( (System.Drawing.Image)( resources.GetObject("ActionResetWinSettings.Image") ) );
      this.ActionResetWinSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionResetWinSettings.Name = "ActionResetWinSettings";
      this.ActionResetWinSettings.Size = new System.Drawing.Size(323, 22);
      this.ActionResetWinSettings.Text = "Reset window settings";
      this.ActionResetWinSettings.Click += new System.EventHandler(this.ActionResetWinSettings_Click);
      // 
      // Sep7
      // 
      this.Sep7.Name = "Sep7";
      this.Sep7.Size = new System.Drawing.Size(320, 6);
      // 
      // ActionShowKeyboardNotice
      // 
      this.ActionShowKeyboardNotice.Image = ( (System.Drawing.Image)( resources.GetObject("ActionShowKeyboardNotice.Image") ) );
      this.ActionShowKeyboardNotice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.ActionShowKeyboardNotice.Name = "ActionShowKeyboardNotice";
      this.ActionShowKeyboardNotice.Size = new System.Drawing.Size(323, 22);
      this.ActionShowKeyboardNotice.Text = "Keyboard shortcuts notice";
      this.ActionShowKeyboardNotice.Click += new System.EventHandler(this.ActionShowKeyboardNotice_Click);
      // 
      // toolStripSeparator27
      // 
      this.toolStripSeparator27.Name = "toolStripSeparator27";
      this.toolStripSeparator27.Size = new System.Drawing.Size(320, 6);
      // 
      // EditExportUseHebrewFontElseUnicodeChars
      // 
      this.EditExportUseHebrewFontElseUnicodeChars.CheckOnClick = true;
      this.EditExportUseHebrewFontElseUnicodeChars.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditExportUseHebrewFontElseUnicodeChars.Name = "EditExportUseHebrewFontElseUnicodeChars";
      this.EditExportUseHebrewFontElseUnicodeChars.Size = new System.Drawing.Size(323, 22);
      this.EditExportUseHebrewFontElseUnicodeChars.Text = "Use Hebrew font else Unicode chars for exports";
      // 
      // toolStripSeparator11
      // 
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new System.Drawing.Size(320, 6);
      // 
      // EditShowTips
      // 
      this.EditShowTips.Checked = true;
      this.EditShowTips.CheckOnClick = true;
      this.EditShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditShowTips.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditShowTips.Name = "EditShowTips";
      this.EditShowTips.Size = new System.Drawing.Size(323, 22);
      this.EditShowTips.Text = "Show menu tips";
      // 
      // EditUseAdvancedDialogBoxes
      // 
      this.EditUseAdvancedDialogBoxes.Checked = true;
      this.EditUseAdvancedDialogBoxes.CheckOnClick = true;
      this.EditUseAdvancedDialogBoxes.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditUseAdvancedDialogBoxes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditUseAdvancedDialogBoxes.Name = "EditUseAdvancedDialogBoxes";
      this.EditUseAdvancedDialogBoxes.Size = new System.Drawing.Size(323, 22);
      this.EditUseAdvancedDialogBoxes.Text = "Advanced dialogs";
      this.EditUseAdvancedDialogBoxes.CheckStateChanged += new System.EventHandler(this.EditDialogBoxesSettings_CheckedChanged);
      // 
      // EditSoundsEnabled
      // 
      this.EditSoundsEnabled.Checked = true;
      this.EditSoundsEnabled.CheckOnClick = true;
      this.EditSoundsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditSoundsEnabled.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditSoundsEnabled.Name = "EditSoundsEnabled";
      this.EditSoundsEnabled.Size = new System.Drawing.Size(323, 22);
      this.EditSoundsEnabled.Text = "Dialogs with sounds";
      this.EditSoundsEnabled.CheckStateChanged += new System.EventHandler(this.EditDialogBoxesSettings_CheckedChanged);
      // 
      // EditShowSuccessDialogs
      // 
      this.EditShowSuccessDialogs.Checked = true;
      this.EditShowSuccessDialogs.CheckOnClick = true;
      this.EditShowSuccessDialogs.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditShowSuccessDialogs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditShowSuccessDialogs.Name = "EditShowSuccessDialogs";
      this.EditShowSuccessDialogs.Size = new System.Drawing.Size(323, 22);
      this.EditShowSuccessDialogs.Text = "Success dialogs instead of sounds";
      this.EditShowSuccessDialogs.CheckStateChanged += new System.EventHandler(this.EditShowSuccessDialogs_CheckStateChanged);
      // 
      // toolStripSeparator15
      // 
      this.toolStripSeparator15.Name = "toolStripSeparator15";
      this.toolStripSeparator15.Size = new System.Drawing.Size(320, 6);
      // 
      // EditConfirmClosing
      // 
      this.EditConfirmClosing.Checked = true;
      this.EditConfirmClosing.CheckOnClick = true;
      this.EditConfirmClosing.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditConfirmClosing.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.EditConfirmClosing.Name = "EditConfirmClosing";
      this.EditConfirmClosing.Size = new System.Drawing.Size(323, 22);
      this.EditConfirmClosing.Text = "Confirm application closing";
      // 
      // PanelMain
      // 
      this.PanelMain.Controls.Add(this.PanelMainOuter);
      this.PanelMain.Controls.Add(this.PanelSepTop);
      this.PanelMain.Controls.Add(this.PanelTitle);
      this.PanelMain.Controls.Add(this.PanelDatabase);
      this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelMain.Location = new System.Drawing.Point(0, 54);
      this.PanelMain.Name = "PanelMain";
      this.PanelMain.Padding = new System.Windows.Forms.Padding(10);
      this.PanelMain.Size = new System.Drawing.Size(959, 485);
      this.PanelMain.TabIndex = 10;
      // 
      // PanelMainOuter
      // 
      this.PanelMainOuter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelMainOuter.Controls.Add(this.PanelMainInner);
      this.PanelMainOuter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelMainOuter.Location = new System.Drawing.Point(10, 84);
      this.PanelMainOuter.Name = "PanelMainOuter";
      this.PanelMainOuter.Padding = new System.Windows.Forms.Padding(1);
      this.PanelMainOuter.Size = new System.Drawing.Size(939, 391);
      this.PanelMainOuter.TabIndex = 18;
      // 
      // PanelMainInner
      // 
      this.PanelMainInner.BackColor = System.Drawing.SystemColors.Control;
      this.PanelMainInner.Controls.Add(this.PanelMainCenter);
      this.PanelMainInner.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelMainInner.Location = new System.Drawing.Point(1, 1);
      this.PanelMainInner.Name = "PanelMainInner";
      this.PanelMainInner.Size = new System.Drawing.Size(937, 389);
      this.PanelMainInner.TabIndex = 0;
      // 
      // PanelMainCenter
      // 
      this.PanelMainCenter.BackColor = System.Drawing.SystemColors.Control;
      this.PanelMainCenter.Controls.Add(this.TabControl);
      this.PanelMainCenter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelMainCenter.Location = new System.Drawing.Point(0, 0);
      this.PanelMainCenter.Name = "PanelMainCenter";
      this.PanelMainCenter.Size = new System.Drawing.Size(937, 389);
      this.PanelMainCenter.TabIndex = 0;
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.TabPageDecode);
      this.TabControl.Controls.Add(this.TabPageGrid);
      this.TabControl.Controls.Add(this.TabPagePopulate);
      this.TabControl.Controls.Add(this.TabPageNormalize);
      this.TabControl.Controls.Add(this.TabPageStatistics);
      this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TabControl.Location = new System.Drawing.Point(0, 0);
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.Size = new System.Drawing.Size(937, 389);
      this.TabControl.TabIndex = 8;
      this.TabControl.TabStop = false;
      this.TabControl.Visible = false;
      // 
      // TabPageDecode
      // 
      this.TabPageDecode.Controls.Add(this.PanelViewDecode);
      this.TabPageDecode.Location = new System.Drawing.Point(4, 22);
      this.TabPageDecode.Name = "TabPageDecode";
      this.TabPageDecode.Padding = new System.Windows.Forms.Padding(3);
      this.TabPageDecode.Size = new System.Drawing.Size(929, 363);
      this.TabPageDecode.TabIndex = 1;
      this.TabPageDecode.Text = "Decode";
      this.TabPageDecode.UseVisualStyleBackColor = true;
      // 
      // PanelViewDecode
      // 
      this.PanelViewDecode.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewDecode.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelViewDecode.Location = new System.Drawing.Point(3, 3);
      this.PanelViewDecode.Name = "PanelViewDecode";
      this.PanelViewDecode.Padding = new System.Windows.Forms.Padding(10);
      this.PanelViewDecode.Size = new System.Drawing.Size(923, 357);
      this.PanelViewDecode.TabIndex = 0;
      // 
      // TabPageGrid
      // 
      this.TabPageGrid.Controls.Add(this.PanelViewGrid);
      this.TabPageGrid.Location = new System.Drawing.Point(4, 22);
      this.TabPageGrid.Name = "TabPageGrid";
      this.TabPageGrid.Padding = new System.Windows.Forms.Padding(3);
      this.TabPageGrid.Size = new System.Drawing.Size(929, 363);
      this.TabPageGrid.TabIndex = 0;
      this.TabPageGrid.Text = "Grid";
      this.TabPageGrid.UseVisualStyleBackColor = true;
      // 
      // PanelViewGrid
      // 
      this.PanelViewGrid.AutoScroll = true;
      this.PanelViewGrid.AutoScrollMinSize = new System.Drawing.Size(50, 0);
      this.PanelViewGrid.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelViewGrid.Location = new System.Drawing.Point(3, 3);
      this.PanelViewGrid.Name = "PanelViewGrid";
      this.PanelViewGrid.Padding = new System.Windows.Forms.Padding(10);
      this.PanelViewGrid.Size = new System.Drawing.Size(923, 357);
      this.PanelViewGrid.TabIndex = 22;
      // 
      // TabPagePopulate
      // 
      this.TabPagePopulate.BackColor = System.Drawing.SystemColors.Control;
      this.TabPagePopulate.Controls.Add(this.PanelViewPopulate);
      this.TabPagePopulate.Location = new System.Drawing.Point(4, 22);
      this.TabPagePopulate.Name = "TabPagePopulate";
      this.TabPagePopulate.Padding = new System.Windows.Forms.Padding(3);
      this.TabPagePopulate.Size = new System.Drawing.Size(929, 363);
      this.TabPagePopulate.TabIndex = 4;
      this.TabPagePopulate.Text = "Populate";
      // 
      // PanelViewPopulate
      // 
      this.PanelViewPopulate.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewPopulate.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelViewPopulate.Location = new System.Drawing.Point(3, 3);
      this.PanelViewPopulate.Name = "PanelViewPopulate";
      this.PanelViewPopulate.Padding = new System.Windows.Forms.Padding(10);
      this.PanelViewPopulate.Size = new System.Drawing.Size(923, 357);
      this.PanelViewPopulate.TabIndex = 2;
      // 
      // TabPageNormalize
      // 
      this.TabPageNormalize.Controls.Add(this.PanelViewNormalize);
      this.TabPageNormalize.Location = new System.Drawing.Point(4, 22);
      this.TabPageNormalize.Name = "TabPageNormalize";
      this.TabPageNormalize.Padding = new System.Windows.Forms.Padding(3);
      this.TabPageNormalize.Size = new System.Drawing.Size(929, 363);
      this.TabPageNormalize.TabIndex = 3;
      this.TabPageNormalize.Text = "Normalize";
      this.TabPageNormalize.UseVisualStyleBackColor = true;
      // 
      // PanelViewNormalize
      // 
      this.PanelViewNormalize.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewNormalize.Controls.Add(this.GridIterations);
      this.PanelViewNormalize.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelViewNormalize.Location = new System.Drawing.Point(3, 3);
      this.PanelViewNormalize.Name = "PanelViewNormalize";
      this.PanelViewNormalize.Padding = new System.Windows.Forms.Padding(10);
      this.PanelViewNormalize.Size = new System.Drawing.Size(923, 357);
      this.PanelViewNormalize.TabIndex = 2;
      // 
      // GridIterations
      // 
      this.GridIterations.AllowUserToAddRows = false;
      this.GridIterations.AllowUserToDeleteRows = false;
      this.GridIterations.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
            | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.GridIterations.AutoGenerateColumns = false;
      this.GridIterations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.GridIterations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIteration,
            this.ColumnRepeatedCount,
            this.ColumnMaxOccurences,
            this.ColumnRemainingRate,
            this.ColumnElapsedCount,
            this.ColumnElapsedAddition});
      this.GridIterations.DataSource = this.BindingSourceIterationRow;
      this.GridIterations.Location = new System.Drawing.Point(13, 13);
      this.GridIterations.Name = "GridIterations";
      this.GridIterations.ReadOnly = true;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.GridIterations.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.GridIterations.RowHeadersVisible = false;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.GridIterations.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.GridIterations.Size = new System.Drawing.Size(671, 331);
      this.GridIterations.TabIndex = 0;
      this.GridIterations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridIterations_CellFormatting);
      // 
      // ColumnIteration
      // 
      this.ColumnIteration.DataPropertyName = "Iteration";
      this.ColumnIteration.FillWeight = 126.9036F;
      this.ColumnIteration.HeaderText = "Iteration";
      this.ColumnIteration.Name = "ColumnIteration";
      this.ColumnIteration.ReadOnly = true;
      this.ColumnIteration.Width = 75;
      // 
      // ColumnRepeatedCount
      // 
      this.ColumnRepeatedCount.DataPropertyName = "RepeatedCount";
      this.ColumnRepeatedCount.FillWeight = 93.27411F;
      this.ColumnRepeatedCount.HeaderText = "Repeated count";
      this.ColumnRepeatedCount.Name = "ColumnRepeatedCount";
      this.ColumnRepeatedCount.ReadOnly = true;
      this.ColumnRepeatedCount.Width = 110;
      // 
      // ColumnMaxOccurences
      // 
      this.ColumnMaxOccurences.DataPropertyName = "MaxOccurences";
      this.ColumnMaxOccurences.FillWeight = 93.27411F;
      this.ColumnMaxOccurences.HeaderText = "Max occurences";
      this.ColumnMaxOccurences.Name = "ColumnMaxOccurences";
      this.ColumnMaxOccurences.ReadOnly = true;
      this.ColumnMaxOccurences.Width = 110;
      // 
      // RemainingRate
      // 
      this.ColumnRemainingRate.DataPropertyName = "RemainingRate";
      this.ColumnRemainingRate.HeaderText = "Remaining rate";
      this.ColumnRemainingRate.Name = "RemainingRate";
      this.ColumnRemainingRate.ReadOnly = true;
      this.ColumnRemainingRate.Width = 110;
      // 
      // ColumnElapsedCount
      // 
      this.ColumnElapsedCount.DataPropertyName = "ElapsedCount";
      this.ColumnElapsedCount.FillWeight = 93.27411F;
      this.ColumnElapsedCount.HeaderText = "Counting";
      this.ColumnElapsedCount.Name = "ColumnElapsedCount";
      this.ColumnElapsedCount.ReadOnly = true;
      this.ColumnElapsedCount.Width = 75;
      // 
      // ColumnElapsedAddition
      // 
      this.ColumnElapsedAddition.DataPropertyName = "ElapsedAddition";
      this.ColumnElapsedAddition.FillWeight = 93.27411F;
      this.ColumnElapsedAddition.HeaderText = "Adding";
      this.ColumnElapsedAddition.Name = "ColumnElapsedAddition";
      this.ColumnElapsedAddition.ReadOnly = true;
      this.ColumnElapsedAddition.Width = 75;
      // 
      // BindingSourceIterationRow
      // 
      this.BindingSourceIterationRow.AllowNew = true;
      this.BindingSourceIterationRow.DataSource = typeof(Ordisoftware.Hebrew.Pi.IterationRow);
      // 
      // TabPageStatistics
      // 
      this.TabPageStatistics.Controls.Add(this.PanelViewStatistics);
      this.TabPageStatistics.Location = new System.Drawing.Point(4, 22);
      this.TabPageStatistics.Name = "TabPageStatistics";
      this.TabPageStatistics.Padding = new System.Windows.Forms.Padding(3);
      this.TabPageStatistics.Size = new System.Drawing.Size(929, 363);
      this.TabPageStatistics.TabIndex = 2;
      this.TabPageStatistics.Text = "Statistics";
      this.TabPageStatistics.UseVisualStyleBackColor = true;
      // 
      // PanelViewStatistics
      // 
      this.PanelViewStatistics.BackColor = System.Drawing.SystemColors.Control;
      this.PanelViewStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelViewStatistics.Location = new System.Drawing.Point(3, 3);
      this.PanelViewStatistics.Name = "PanelViewStatistics";
      this.PanelViewStatistics.Padding = new System.Windows.Forms.Padding(10);
      this.PanelViewStatistics.Size = new System.Drawing.Size(923, 357);
      this.PanelViewStatistics.TabIndex = 1;
      // 
      // PanelSepTop
      // 
      this.PanelSepTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelSepTop.Location = new System.Drawing.Point(10, 74);
      this.PanelSepTop.Name = "PanelSepTop";
      this.PanelSepTop.Size = new System.Drawing.Size(939, 10);
      this.PanelSepTop.TabIndex = 16;
      // 
      // PanelTitle
      // 
      this.PanelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelTitle.Controls.Add(this.PanelTitleInner);
      this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelTitle.Location = new System.Drawing.Point(10, 50);
      this.PanelTitle.Name = "PanelTitle";
      this.PanelTitle.Padding = new System.Windows.Forms.Padding(1);
      this.PanelTitle.Size = new System.Drawing.Size(939, 24);
      this.PanelTitle.TabIndex = 3;
      // 
      // PanelTitleInner
      // 
      this.PanelTitleInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.PanelTitleInner.Controls.Add(this.LabelTitleCenter);
      this.PanelTitleInner.Controls.Add(this.LabelTitleLeft);
      this.PanelTitleInner.Controls.Add(this.LabelTitleRight);
      this.PanelTitleInner.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelTitleInner.Location = new System.Drawing.Point(1, 1);
      this.PanelTitleInner.Name = "PanelTitleInner";
      this.PanelTitleInner.Size = new System.Drawing.Size(937, 22);
      this.PanelTitleInner.TabIndex = 4;
      // 
      // LabelTitleCenter
      // 
      this.LabelTitleCenter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.LabelTitleCenter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LabelTitleCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
      this.LabelTitleCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.LabelTitleCenter.Location = new System.Drawing.Point(150, 0);
      this.LabelTitleCenter.Name = "LabelTitleCenter";
      this.LabelTitleCenter.Size = new System.Drawing.Size(637, 22);
      this.LabelTitleCenter.TabIndex = 2;
      this.LabelTitleCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // LabelTitleLeft
      // 
      this.LabelTitleLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.LabelTitleLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.LabelTitleLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
      this.LabelTitleLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.LabelTitleLeft.Location = new System.Drawing.Point(0, 0);
      this.LabelTitleLeft.Name = "LabelTitleLeft";
      this.LabelTitleLeft.Size = new System.Drawing.Size(150, 22);
      this.LabelTitleLeft.TabIndex = 0;
      this.LabelTitleLeft.Text = "PI DECIMALS";
      this.LabelTitleLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // LabelTitleRight
      // 
      this.LabelTitleRight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.LabelTitleRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.LabelTitleRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
      this.LabelTitleRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.LabelTitleRight.Location = new System.Drawing.Point(787, 0);
      this.LabelTitleRight.Name = "LabelTitleRight";
      this.LabelTitleRight.Size = new System.Drawing.Size(150, 22);
      this.LabelTitleRight.TabIndex = 1;
      this.LabelTitleRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // PanelSearchFilters
      // 
      this.PanelSearchFilters.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelSearchFilters.Location = new System.Drawing.Point(10, 10);
      this.PanelSearchFilters.Name = "PanelSearchFilters";
      this.PanelSearchFilters.Size = new System.Drawing.Size(728, 313);
      this.PanelSearchFilters.TabIndex = 4;
      // 
      // SelectSearchType
      // 
      this.SelectSearchType.Appearance = System.Windows.Forms.TabAppearance.Buttons;
      this.SelectSearchType.Dock = System.Windows.Forms.DockStyle.Left;
      this.SelectSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
      this.SelectSearchType.Location = new System.Drawing.Point(0, 0);
      this.SelectSearchType.Name = "SelectSearchType";
      this.SelectSearchType.SelectedIndex = 0;
      this.SelectSearchType.Size = new System.Drawing.Size(518, 313);
      this.SelectSearchType.TabIndex = 0;
      // 
      // SelectSearchTypeVerses
      // 
      this.SelectSearchTypeVerses.BackColor = System.Drawing.SystemColors.Control;
      this.SelectSearchTypeVerses.Location = new System.Drawing.Point(4, 27);
      this.SelectSearchTypeVerses.Name = "SelectSearchTypeVerses";
      this.SelectSearchTypeVerses.Size = new System.Drawing.Size(510, 282);
      this.SelectSearchTypeVerses.TabIndex = 2;
      this.SelectSearchTypeVerses.Text = "Verses";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(510, 282);
      this.panel1.TabIndex = 0;
      // 
      // SelectSearchRequestAllPartiallyTranslated
      // 
      this.SelectSearchRequestAllPartiallyTranslated.AutoSize = true;
      this.SelectSearchRequestAllPartiallyTranslated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchRequestAllPartiallyTranslated.Location = new System.Drawing.Point(15, 65);
      this.SelectSearchRequestAllPartiallyTranslated.Name = "SelectSearchRequestAllPartiallyTranslated";
      this.SelectSearchRequestAllPartiallyTranslated.Size = new System.Drawing.Size(178, 19);
      this.SelectSearchRequestAllPartiallyTranslated.TabIndex = 2;
      this.SelectSearchRequestAllPartiallyTranslated.Text = "All partially translated verses";
      this.SelectSearchRequestAllPartiallyTranslated.UseVisualStyleBackColor = true;
      // 
      // SelectSearchRequestAllFullyTranslated
      // 
      this.SelectSearchRequestAllFullyTranslated.AutoSize = true;
      this.SelectSearchRequestAllFullyTranslated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchRequestAllFullyTranslated.Location = new System.Drawing.Point(15, 40);
      this.SelectSearchRequestAllFullyTranslated.Name = "SelectSearchRequestAllFullyTranslated";
      this.SelectSearchRequestAllFullyTranslated.Size = new System.Drawing.Size(157, 19);
      this.SelectSearchRequestAllFullyTranslated.TabIndex = 1;
      this.SelectSearchRequestAllFullyTranslated.Text = "All fully translated verses";
      this.SelectSearchRequestAllFullyTranslated.UseVisualStyleBackColor = true;
      // 
      // SelectSearchRequestAllUntranslated
      // 
      this.SelectSearchRequestAllUntranslated.AutoSize = true;
      this.SelectSearchRequestAllUntranslated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchRequestAllUntranslated.Location = new System.Drawing.Point(15, 90);
      this.SelectSearchRequestAllUntranslated.Name = "SelectSearchRequestAllUntranslated";
      this.SelectSearchRequestAllUntranslated.Size = new System.Drawing.Size(147, 19);
      this.SelectSearchRequestAllUntranslated.TabIndex = 3;
      this.SelectSearchRequestAllUntranslated.Text = "All untranslated verses";
      this.SelectSearchRequestAllUntranslated.UseVisualStyleBackColor = true;
      // 
      // SelectSearchRequestAllTranslated
      // 
      this.SelectSearchRequestAllTranslated.AutoSize = true;
      this.SelectSearchRequestAllTranslated.Checked = true;
      this.SelectSearchRequestAllTranslated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchRequestAllTranslated.Location = new System.Drawing.Point(15, 15);
      this.SelectSearchRequestAllTranslated.Name = "SelectSearchRequestAllTranslated";
      this.SelectSearchRequestAllTranslated.Size = new System.Drawing.Size(133, 19);
      this.SelectSearchRequestAllTranslated.TabIndex = 0;
      this.SelectSearchRequestAllTranslated.TabStop = true;
      this.SelectSearchRequestAllTranslated.Text = "All translated verses";
      this.SelectSearchRequestAllTranslated.UseVisualStyleBackColor = true;
      // 
      // SelectSearchTypeTranslation
      // 
      this.SelectSearchTypeTranslation.BackColor = System.Drawing.SystemColors.Control;
      this.SelectSearchTypeTranslation.Location = new System.Drawing.Point(4, 27);
      this.SelectSearchTypeTranslation.Name = "SelectSearchTypeTranslation";
      this.SelectSearchTypeTranslation.Size = new System.Drawing.Size(510, 282);
      this.SelectSearchTypeTranslation.TabIndex = 1;
      this.SelectSearchTypeTranslation.Text = "Translation";
      // 
      // PanelSeparator
      // 
      this.PanelSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelSeparator.Location = new System.Drawing.Point(0, 231);
      this.PanelSeparator.Name = "PanelSeparator";
      this.PanelSeparator.Size = new System.Drawing.Size(510, 8);
      this.PanelSeparator.TabIndex = 6;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
      this.panel2.Size = new System.Drawing.Size(510, 231);
      this.panel2.TabIndex = 5;
      // 
      // SelectSearchTranslationOnlyTranslations
      // 
      this.SelectSearchTranslationOnlyTranslations.AutoSize = true;
      this.SelectSearchTranslationOnlyTranslations.Checked = true;
      this.SelectSearchTranslationOnlyTranslations.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchTranslationOnlyTranslations.Location = new System.Drawing.Point(18, 81);
      this.SelectSearchTranslationOnlyTranslations.Name = "SelectSearchTranslationOnlyTranslations";
      this.SelectSearchTranslationOnlyTranslations.Size = new System.Drawing.Size(115, 19);
      this.SelectSearchTranslationOnlyTranslations.TabIndex = 0;
      this.SelectSearchTranslationOnlyTranslations.TabStop = true;
      this.SelectSearchTranslationOnlyTranslations.Text = "Only translations";
      this.SelectSearchTranslationOnlyTranslations.UseVisualStyleBackColor = true;
      // 
      // SelectSearchTranslationIncludeComments
      // 
      this.SelectSearchTranslationIncludeComments.AutoSize = true;
      this.SelectSearchTranslationIncludeComments.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchTranslationIncludeComments.Location = new System.Drawing.Point(18, 99);
      this.SelectSearchTranslationIncludeComments.Name = "SelectSearchTranslationIncludeComments";
      this.SelectSearchTranslationIncludeComments.Size = new System.Drawing.Size(172, 19);
      this.SelectSearchTranslationIncludeComments.TabIndex = 1;
      this.SelectSearchTranslationIncludeComments.Text = "Include title and comments";
      this.SelectSearchTranslationIncludeComments.UseVisualStyleBackColor = true;
      // 
      // SelectSearchTranslationOnlyComments
      // 
      this.SelectSearchTranslationOnlyComments.AutoSize = true;
      this.SelectSearchTranslationOnlyComments.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchTranslationOnlyComments.Location = new System.Drawing.Point(18, 117);
      this.SelectSearchTranslationOnlyComments.Name = "SelectSearchTranslationOnlyComments";
      this.SelectSearchTranslationOnlyComments.Size = new System.Drawing.Size(156, 19);
      this.SelectSearchTranslationOnlyComments.TabIndex = 2;
      this.SelectSearchTranslationOnlyComments.Text = "Only title and comments";
      this.SelectSearchTranslationOnlyComments.UseVisualStyleBackColor = true;
      // 
      // LabelSearchTranslationHelp
      // 
      this.LabelSearchTranslationHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.LabelSearchTranslationHelp.Location = new System.Drawing.Point(15, 15);
      this.LabelSearchTranslationHelp.Name = "LabelSearchTranslationHelp";
      this.LabelSearchTranslationHelp.Size = new System.Drawing.Size(502, 65);
      this.LabelSearchTranslationHelp.TabIndex = 4;
      // 
      // SelectSearchTypeHebrew
      // 
      this.SelectSearchTypeHebrew.BackColor = System.Drawing.SystemColors.Control;
      this.SelectSearchTypeHebrew.Location = new System.Drawing.Point(4, 27);
      this.SelectSearchTypeHebrew.Name = "SelectSearchTypeHebrew";
      this.SelectSearchTypeHebrew.Size = new System.Drawing.Size(510, 282);
      this.SelectSearchTypeHebrew.TabIndex = 0;
      this.SelectSearchTypeHebrew.Text = "Hebrew";
      // 
      // PanelSearchTop
      // 
      this.PanelSearchTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelSearchTop.Location = new System.Drawing.Point(0, 0);
      this.PanelSearchTop.Name = "PanelSearchTop";
      this.PanelSearchTop.Size = new System.Drawing.Size(510, 282);
      this.PanelSearchTop.TabIndex = 0;
      // 
      // PanelSearchFiltersRight
      // 
      this.PanelSearchFiltersRight.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelSearchFiltersRight.Location = new System.Drawing.Point(518, 0);
      this.PanelSearchFiltersRight.Name = "PanelSearchFiltersRight";
      this.PanelSearchFiltersRight.Size = new System.Drawing.Size(210, 313);
      this.PanelSearchFiltersRight.TabIndex = 1;
      // 
      // ActionSearchClear
      // 
      this.ActionSearchClear.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.ActionSearchClear.Enabled = false;
      this.ActionSearchClear.FlatAppearance.BorderSize = 0;
      this.ActionSearchClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchClear.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSearchClear.Image") ) );
      this.ActionSearchClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchClear.Location = new System.Drawing.Point(50, 267);
      this.ActionSearchClear.Margin = new System.Windows.Forms.Padding(0);
      this.ActionSearchClear.Name = "ActionSearchClear";
      this.ActionSearchClear.Size = new System.Drawing.Size(42, 42);
      this.ActionSearchClear.TabIndex = 1;
      this.ActionSearchClear.UseVisualStyleBackColor = true;
      // 
      // ActionSearchNavigateLast
      // 
      this.ActionSearchNavigateLast.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.ActionSearchNavigateLast.Enabled = false;
      this.ActionSearchNavigateLast.FlatAppearance.BorderSize = 0;
      this.ActionSearchNavigateLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchNavigateLast.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSearchNavigateLast.Image") ) );
      this.ActionSearchNavigateLast.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchNavigateLast.Location = new System.Drawing.Point(-341, 267);
      this.ActionSearchNavigateLast.Margin = new System.Windows.Forms.Padding(0);
      this.ActionSearchNavigateLast.Name = "ActionSearchNavigateLast";
      this.ActionSearchNavigateLast.Size = new System.Drawing.Size(30, 42);
      this.ActionSearchNavigateLast.TabIndex = 13;
      this.ActionSearchNavigateLast.UseVisualStyleBackColor = true;
      // 
      // ActionSearchNavigateNext
      // 
      this.ActionSearchNavigateNext.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.ActionSearchNavigateNext.Enabled = false;
      this.ActionSearchNavigateNext.FlatAppearance.BorderSize = 0;
      this.ActionSearchNavigateNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchNavigateNext.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSearchNavigateNext.Image") ) );
      this.ActionSearchNavigateNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchNavigateNext.Location = new System.Drawing.Point(-374, 267);
      this.ActionSearchNavigateNext.Margin = new System.Windows.Forms.Padding(0);
      this.ActionSearchNavigateNext.Name = "ActionSearchNavigateNext";
      this.ActionSearchNavigateNext.Size = new System.Drawing.Size(30, 42);
      this.ActionSearchNavigateNext.TabIndex = 12;
      this.ActionSearchNavigateNext.UseVisualStyleBackColor = true;
      // 
      // ActionSearchNavigatePrevious
      // 
      this.ActionSearchNavigatePrevious.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.ActionSearchNavigatePrevious.Enabled = false;
      this.ActionSearchNavigatePrevious.FlatAppearance.BorderSize = 0;
      this.ActionSearchNavigatePrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchNavigatePrevious.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSearchNavigatePrevious.Image") ) );
      this.ActionSearchNavigatePrevious.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchNavigatePrevious.Location = new System.Drawing.Point(-534, 267);
      this.ActionSearchNavigatePrevious.Margin = new System.Windows.Forms.Padding(0);
      this.ActionSearchNavigatePrevious.Name = "ActionSearchNavigatePrevious";
      this.ActionSearchNavigatePrevious.Size = new System.Drawing.Size(30, 42);
      this.ActionSearchNavigatePrevious.TabIndex = 11;
      this.ActionSearchNavigatePrevious.UseVisualStyleBackColor = true;
      // 
      // ActionNavigateSearchFirst
      // 
      this.ActionNavigateSearchFirst.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.ActionNavigateSearchFirst.Enabled = false;
      this.ActionNavigateSearchFirst.FlatAppearance.BorderSize = 0;
      this.ActionNavigateSearchFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionNavigateSearchFirst.Image = ( (System.Drawing.Image)( resources.GetObject("ActionNavigateSearchFirst.Image") ) );
      this.ActionNavigateSearchFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionNavigateSearchFirst.Location = new System.Drawing.Point(-567, 267);
      this.ActionNavigateSearchFirst.Margin = new System.Windows.Forms.Padding(0);
      this.ActionNavigateSearchFirst.Name = "ActionNavigateSearchFirst";
      this.ActionNavigateSearchFirst.Size = new System.Drawing.Size(30, 42);
      this.ActionNavigateSearchFirst.TabIndex = 10;
      this.ActionNavigateSearchFirst.UseVisualStyleBackColor = true;
      // 
      // ActionSearchRun
      // 
      this.ActionSearchRun.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.ActionSearchRun.Enabled = false;
      this.ActionSearchRun.FlatAppearance.BorderSize = 0;
      this.ActionSearchRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchRun.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSearchRun.Image") ) );
      this.ActionSearchRun.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchRun.Location = new System.Drawing.Point(5, 267);
      this.ActionSearchRun.Margin = new System.Windows.Forms.Padding(0);
      this.ActionSearchRun.Name = "ActionSearchRun";
      this.ActionSearchRun.Size = new System.Drawing.Size(42, 42);
      this.ActionSearchRun.TabIndex = 0;
      this.ActionSearchRun.UseVisualStyleBackColor = true;
      // 
      // EditSearchInTorah
      // 
      this.EditSearchInTorah.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.EditSearchInTorah.AutoSize = true;
      this.EditSearchInTorah.Checked = true;
      this.EditSearchInTorah.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditSearchInTorah.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
      this.EditSearchInTorah.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.EditSearchInTorah.Location = new System.Drawing.Point(16, 169);
      this.EditSearchInTorah.Name = "EditSearchInTorah";
      this.EditSearchInTorah.Size = new System.Drawing.Size(58, 19);
      this.EditSearchInTorah.TabIndex = 5;
      this.EditSearchInTorah.Text = "Torah";
      this.EditSearchInTorah.UseVisualStyleBackColor = true;
      // 
      // EditSearchInNeviim
      // 
      this.EditSearchInNeviim.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.EditSearchInNeviim.AutoSize = true;
      this.EditSearchInNeviim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
      this.EditSearchInNeviim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.EditSearchInNeviim.Location = new System.Drawing.Point(16, 189);
      this.EditSearchInNeviim.Name = "EditSearchInNeviim";
      this.EditSearchInNeviim.Size = new System.Drawing.Size(67, 19);
      this.EditSearchInNeviim.TabIndex = 6;
      this.EditSearchInNeviim.Text = "Nevi\'im";
      this.EditSearchInNeviim.UseVisualStyleBackColor = true;
      // 
      // EditSearchInKetouvim
      // 
      this.EditSearchInKetouvim.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.EditSearchInKetouvim.AutoSize = true;
      this.EditSearchInKetouvim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
      this.EditSearchInKetouvim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.EditSearchInKetouvim.Location = new System.Drawing.Point(16, 209);
      this.EditSearchInKetouvim.Name = "EditSearchInKetouvim";
      this.EditSearchInKetouvim.Size = new System.Drawing.Size(77, 19);
      this.EditSearchInKetouvim.TabIndex = 7;
      this.EditSearchInKetouvim.Text = "Ketouvim";
      this.EditSearchInKetouvim.UseVisualStyleBackColor = true;
      // 
      // SelectSearchPaging
      // 
      this.SelectSearchPaging.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.SelectSearchPaging.AutoSize = false;
      this.SelectSearchPaging.Enabled = false;
      this.SelectSearchPaging.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.SelectSearchPaging.Location = new System.Drawing.Point(-506, 303);
      this.SelectSearchPaging.Maximum = 1;
      this.SelectSearchPaging.Minimum = 1;
      this.SelectSearchPaging.Name = "SelectSearchPaging";
      this.SelectSearchPaging.Size = new System.Drawing.Size(135, 18);
      this.SelectSearchPaging.TabIndex = 50;
      this.SelectSearchPaging.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SelectSearchPaging.Value = 1;
      // 
      // SelectSearchInBook
      // 
      this.SelectSearchInBook.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
            | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.SelectSearchInBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectSearchInBook.Enabled = false;
      this.SelectSearchInBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
      this.SelectSearchInBook.FormattingEnabled = true;
      this.SelectSearchInBook.ItemHeight = 15;
      this.SelectSearchInBook.Location = new System.Drawing.Point(16, 232);
      this.SelectSearchInBook.Name = "SelectSearchInBook";
      this.SelectSearchInBook.Size = new System.Drawing.Size(0, 23);
      this.SelectSearchInBook.TabIndex = 9;
      // 
      // ActionSearchInAddAll
      // 
      this.ActionSearchInAddAll.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.ActionSearchInAddAll.FlatAppearance.BorderSize = 0;
      this.ActionSearchInAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchInAddAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
      this.ActionSearchInAddAll.ForeColor = System.Drawing.Color.DarkBlue;
      this.ActionSearchInAddAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchInAddAll.Location = new System.Drawing.Point(12, 145);
      this.ActionSearchInAddAll.Name = "ActionSearchInAddAll";
      this.ActionSearchInAddAll.Size = new System.Drawing.Size(18, 18);
      this.ActionSearchInAddAll.TabIndex = 3;
      this.ActionSearchInAddAll.Text = "+";
      this.ActionSearchInAddAll.UseVisualStyleBackColor = true;
      // 
      // ActionSearchInRemoveAll
      // 
      this.ActionSearchInRemoveAll.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.ActionSearchInRemoveAll.FlatAppearance.BorderSize = 0;
      this.ActionSearchInRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchInRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
      this.ActionSearchInRemoveAll.ForeColor = System.Drawing.Color.DarkBlue;
      this.ActionSearchInRemoveAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchInRemoveAll.Location = new System.Drawing.Point(31, 145);
      this.ActionSearchInRemoveAll.Name = "ActionSearchInRemoveAll";
      this.ActionSearchInRemoveAll.Size = new System.Drawing.Size(18, 18);
      this.ActionSearchInRemoveAll.TabIndex = 4;
      this.ActionSearchInRemoveAll.Text = "-";
      this.ActionSearchInRemoveAll.UseVisualStyleBackColor = true;
      // 
      // ActionSearchWordOpenInLetters
      // 
      this.ActionSearchWordOpenInLetters.FlatAppearance.BorderSize = 0;
      this.ActionSearchWordOpenInLetters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSearchWordOpenInLetters.Image = ( (System.Drawing.Image)( resources.GetObject("ActionSearchWordOpenInLetters.Image") ) );
      this.ActionSearchWordOpenInLetters.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSearchWordOpenInLetters.Location = new System.Drawing.Point(10, 24);
      this.ActionSearchWordOpenInLetters.Margin = new System.Windows.Forms.Padding(0);
      this.ActionSearchWordOpenInLetters.Name = "ActionSearchWordOpenInLetters";
      this.ActionSearchWordOpenInLetters.Size = new System.Drawing.Size(34, 34);
      this.ActionSearchWordOpenInLetters.TabIndex = 2;
      this.ActionSearchWordOpenInLetters.UseVisualStyleBackColor = true;
      // 
      // PanelViewSearchSeparator
      // 
      this.PanelViewSearchSeparator.Dock = System.Windows.Forms.DockStyle.Top;
      this.PanelViewSearchSeparator.Location = new System.Drawing.Point(10, 323);
      this.PanelViewSearchSeparator.Name = "PanelViewSearchSeparator";
      this.PanelViewSearchSeparator.Size = new System.Drawing.Size(728, 10);
      this.PanelViewSearchSeparator.TabIndex = 0;
      // 
      // PanelSearchResultsOuter
      // 
      this.PanelSearchResultsOuter.AutoScroll = true;
      this.PanelSearchResultsOuter.BackColor = System.Drawing.SystemColors.Window;
      this.PanelSearchResultsOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelSearchResultsOuter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelSearchResultsOuter.Location = new System.Drawing.Point(10, 333);
      this.PanelSearchResultsOuter.Name = "PanelSearchResultsOuter";
      this.PanelSearchResultsOuter.Padding = new System.Windows.Forms.Padding(10);
      this.PanelSearchResultsOuter.Size = new System.Drawing.Size(728, 0);
      this.PanelSearchResultsOuter.TabIndex = 1;
      // 
      // PanelSearchResults
      // 
      this.PanelSearchResults.AutoScroll = true;
      this.PanelSearchResults.BackColor = System.Drawing.SystemColors.Window;
      this.PanelSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelSearchResults.Location = new System.Drawing.Point(10, 10);
      this.PanelSearchResults.Name = "PanelSearchResults";
      this.PanelSearchResults.Padding = new System.Windows.Forms.Padding(10);
      this.PanelSearchResults.Size = new System.Drawing.Size(706, 0);
      this.PanelSearchResults.TabIndex = 0;
      // 
      // TimerBatch
      // 
      this.TimerBatch.Interval = 1000;
      this.TimerBatch.Tick += new System.EventHandler(this.TimerBatch_Tick);
      // 
      // TimerMemory
      // 
      this.TimerMemory.Enabled = true;
      this.TimerMemory.Interval = 5000;
      this.TimerMemory.Tick += new System.EventHandler(this.TimerMemory_Tick);
      // 
      // TimerTooltip
      // 
      this.TimerTooltip.Interval = 500;
      // 
      // EditSearchTranslation
      // 
      this.EditSearchTranslation.BackColor = System.Drawing.Color.AliceBlue;
      this.EditSearchTranslation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditSearchTranslation.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditSearchTranslation.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.EditSearchTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F);
      this.EditSearchTranslation.Location = new System.Drawing.Point(0, 239);
      this.EditSearchTranslation.Name = "EditSearchTranslation";
      this.EditSearchTranslation.Size = new System.Drawing.Size(510, 43);
      this.EditSearchTranslation.SpellCheckAllowed = true;
      this.EditSearchTranslation.TabIndex = 3;
      // 
      // EditSearchWord
      // 
      this.EditSearchWord.BackColor = System.Drawing.Color.Transparent;
      this.EditSearchWord.ContextMenuDetailsVisible = false;
      this.EditSearchWord.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditSearchWord.InitialWord = null;
      this.EditSearchWord.Location = new System.Drawing.Point(0, 0);
      this.EditSearchWord.MarginX = -5;
      this.EditSearchWord.Name = "EditSearchWord";
      this.EditSearchWord.ShowBottomPanel = false;
      this.EditSearchWord.ShowGematria = false;
      this.EditSearchWord.ShowValues = false;
      this.EditSearchWord.Size = new System.Drawing.Size(510, 282);
      this.EditSearchWord.TabIndex = 0;
      // 
      // EditSearchPaging
      // 
      this.EditSearchPaging.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.EditSearchPaging.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditSearchPaging.Enabled = false;
      this.EditSearchPaging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
      this.EditSearchPaging.Location = new System.Drawing.Point(-499, 278);
      this.EditSearchPaging.Name = "EditSearchPaging";
      this.EditSearchPaging.ReadOnly = true;
      this.EditSearchPaging.Size = new System.Drawing.Size(120, 21);
      this.EditSearchPaging.SpellCheckAllowed = false;
      this.EditSearchPaging.TabIndex = 14;
      this.EditSearchPaging.TabStop = false;
      this.EditSearchPaging.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // EditChapterOriginal
      // 
      this.EditChapterOriginal.BackColor = System.Drawing.SystemColors.Window;
      this.EditChapterOriginal.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.EditChapterOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditChapterOriginal.Location = new System.Drawing.Point(10, 10);
      this.EditChapterOriginal.Name = "EditChapterOriginal";
      this.EditChapterOriginal.ReadOnly = true;
      this.EditChapterOriginal.SelectionAlignment = Ordisoftware.Core.TextAlign.Left;
      this.EditChapterOriginal.Size = new System.Drawing.Size(728, 234);
      this.EditChapterOriginal.TabIndex = 0;
      this.EditChapterOriginal.Text = "";
      // 
      // EditChapterELS50
      // 
      this.EditChapterELS50.BackColor = System.Drawing.SystemColors.Window;
      this.EditChapterELS50.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.EditChapterELS50.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditChapterELS50.Location = new System.Drawing.Point(10, 10);
      this.EditChapterELS50.Name = "EditChapterELS50";
      this.EditChapterELS50.ReadOnly = true;
      this.EditChapterELS50.SelectionAlignment = Ordisoftware.Core.TextAlign.Left;
      this.EditChapterELS50.Size = new System.Drawing.Size(728, 234);
      this.EditChapterELS50.TabIndex = 1;
      this.EditChapterELS50.Text = "";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(959, 561);
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.StatusStrip);
      this.Controls.Add(this.ToolStrip);
      this.MinimumSize = new System.Drawing.Size(975, 600);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Hebrew Pi";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.PanelDatabase.ResumeLayout(false);
      this.StatusStrip.ResumeLayout(false);
      this.StatusStrip.PerformLayout();
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.PanelMain.ResumeLayout(false);
      this.PanelMainOuter.ResumeLayout(false);
      this.PanelMainInner.ResumeLayout(false);
      this.PanelMainCenter.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.TabPageDecode.ResumeLayout(false);
      this.TabPageGrid.ResumeLayout(false);
      this.TabPagePopulate.ResumeLayout(false);
      this.TabPageNormalize.ResumeLayout(false);
      this.PanelViewNormalize.ResumeLayout(false);
      ( (System.ComponentModel.ISupportInitialize)( this.GridIterations ) ).EndInit();
      ( (System.ComponentModel.ISupportInitialize)( this.BindingSourceIterationRow ) ).EndInit();
      this.TabPageStatistics.ResumeLayout(false);
      this.PanelTitle.ResumeLayout(false);
      this.PanelTitleInner.ResumeLayout(false);
      ( (System.ComponentModel.ISupportInitialize)( this.SelectSearchPaging ) ).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Panel PanelDatabase;
    private ComboBox SelectFileName;
    private StatusStrip StatusStrip;
    private Button ActionDbOpen;
    private ToolStripStatusLabel LabelStatusInfo;
    private ToolStripStatusLabel LabelStatusTimeBatch;
    private ToolStripStatusLabel LabelStatusAction;
    private ToolStripStatusLabel LabelStatusSep1;
    private ToolStripStatusLabel LabelStatusSep2;
    private Button ActionDbClose;
    private ComboBox SelectDbCache;
    internal ToolStrip ToolStrip;
    private ToolStripButton ActionExit;
    private ToolStripSeparator ToolStripSeparatorExit;
    internal ToolStripButton ActionPreferences;
    private ToolStripDropDownButton ActionBookmarks;
    private ToolStripMenuItem ActionAddBookmark;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem ActionSortBookmarks;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripMenuItem ActionClearBookmarks;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem ActionGoToBookmarkMain;
    private ToolStripSeparator SeparatorBookmarks;
    private ToolStripSeparator toolStripSeparator19;
    private ToolStripDropDownButton ActionHistory;
    private ToolStripMenuItem ActionClearHistory;
    private ToolStripSeparator SeparatorHistory;
    private ToolStripButton ActionHistoryBack;
    private ToolStripButton ActionHistoryNext;
    private ToolStripSeparator toolStripSeparator13;
    private ToolStripDropDownButton ActionDatabase;
    private ToolStripMenuItem ActionDatabaseNew;
    private ToolStripMenuItem ActionDatabaseRestore;
    private ToolStripMenuItem ActionDatabaseBackup;
    private ToolStripSeparator toolStripSeparator22;
    private ToolStripMenuItem ActionVacuum;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem ActionOpenFolderExport;
    private ToolStripMenuItem ActionOpenFolderBackup;
    private ToolStripMenuItem ActionOpenFolderDatabase;
    private ToolStripSeparator toolStripSeparator20;
    private ToolStripDropDownButton ActionTools;
    private ToolStripSeparator toolStripSeparator28;
    private ToolStripMenuItem ActionShowTranscriptionGuide;
    private ToolStripMenuItem ActionShowGrammarGuide;
    private ToolStripMenuItem ActionOpenHebrewLetters;
    private ToolStripMenuItem ActionOpenCalculator;
    private ToolStripSeparator toolStripSeparator29;
    private ToolStripMenuItem ActionTakeScreenshotWindow;
    private ToolStripMenuItem ActionTakeScreenshotView;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem ActionCopyToClipboard;
    internal ToolStripMenuItem ActionRefresh;
    private ToolStripSeparator SeparatorImportConcordances;
    private ToolStripDropDownButton ActionWebLinks;
    internal ToolStripDropDownButton ActionInformation;
    private ToolStripSeparator MainMenuSeparatorLeftButtons;
    private ToolStripDropDownButton ActionSettings;
    private ToolStripMenuItem ActionScreenPosition;
    internal ToolStripMenuItem EditScreenNone;
    internal ToolStripMenuItem EditScreenTopLeft;
    internal ToolStripMenuItem EditScreenTopRight;
    internal ToolStripMenuItem EditScreenBottomLeft;
    internal ToolStripMenuItem EditScreenBottomRight;
    internal ToolStripMenuItem EditScreenCenter;
    private ToolStripMenuItem ActionResetWinSettings;
    private ToolStripSeparator Sep7;
    private ToolStripMenuItem ActionShowKeyboardNotice;
    private ToolStripSeparator toolStripSeparator11;
    internal ToolStripMenuItem EditShowTips;
    internal ToolStripMenuItem EditUseAdvancedDialogBoxes;
    internal ToolStripMenuItem EditSoundsEnabled;
    internal ToolStripMenuItem EditShowSuccessDialogs;
    private ToolStripSeparator toolStripSeparator15;
    internal ToolStripMenuItem EditConfirmClosing;
    private Panel PanelMain;
    private Panel PanelMainOuter;
    private Panel PanelMainInner;
    private Panel PanelMainCenter;
    private Panel PanelSepTop;
    private Panel PanelTitle;
    private Panel PanelTitleInner;
    internal Label LabelTitleCenter;
    internal Label LabelTitleLeft;
    internal Label LabelTitleRight;
    private TabControl TabControl;
    private TabPage TabPageGrid;
    internal Panel PanelViewGrid;
    private TabPage TabPageDecode;
    private Panel PanelViewDecode;
    private TabPage TabPageNormalize;
    private Panel PanelViewNormalize;
    private TabPage TabPageStatistics;
    private Panel PanelViewStatistics;
    private Panel PanelSearchFilters;
    internal TabControl SelectSearchType;
    private TabPage SelectSearchTypeVerses;
    private Panel panel1;
    private RadioButton SelectSearchRequestAllPartiallyTranslated;
    private RadioButton SelectSearchRequestAllFullyTranslated;
    private RadioButton SelectSearchRequestAllUntranslated;
    private RadioButton SelectSearchRequestAllTranslated;
    private TabPage SelectSearchTypeTranslation;
    private TextBoxEx EditSearchTranslation;
    private Panel PanelSeparator;
    private Panel panel2;
    private RadioButton SelectSearchTranslationOnlyTranslations;
    private RadioButton SelectSearchTranslationIncludeComments;
    private RadioButton SelectSearchTranslationOnlyComments;
    private Label LabelSearchTranslationHelp;
    internal TabPage SelectSearchTypeHebrew;
    private Panel PanelSearchTop;
    internal LettersControl EditSearchWord;
    private Panel PanelSearchFiltersRight;
    private Button ActionSearchClear;
    private Button ActionSearchNavigateLast;
    private Button ActionSearchNavigateNext;
    private Button ActionSearchNavigatePrevious;
    private Button ActionNavigateSearchFirst;
    internal Button ActionSearchRun;
    internal CheckBox EditSearchInTorah;
    internal CheckBox EditSearchInNeviim;
    internal CheckBox EditSearchInKetouvim;
    private TextBoxEx EditSearchPaging;
    private TrackBar SelectSearchPaging;
    private ComboBox SelectSearchInBook;
    private Button ActionSearchInAddAll;
    private Button ActionSearchInRemoveAll;
    private Button ActionSearchWordOpenInLetters;
    private Panel PanelViewSearchSeparator;
    private Panel PanelSearchResultsOuter;
    private Panel PanelSearchResults;
    private RichTextBoxEx EditChapterOriginal;
    private RichTextBoxEx EditChapterELS50;
    private ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.Timer TimerBatch;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton ActionStop;
    private ToolStripButton ActionContinue;
    private ToolStripButton ActionRun;
    private ToolStripSeparator toolStripSeparator8;
    private TabPage TabPagePopulate;
    private Panel PanelViewPopulate;
    private ToolStripSeparator toolStripSeparator27;
    internal ToolStripMenuItem EditExportUseHebrewFontElseUnicodeChars;
    private ToolStripButton ActionPause;
    private ToolStripMenuItem ActionDatabaseSetCacheSize;
    private System.Windows.Forms.Timer TimerMemory;
    private ToolStripStatusLabel LabelStatusFreeMem;
    private ToolStripButton ActionViewPopulate;
    private ToolStripButton ActionViewNormalize;
    private ToolStripButton ActionViewStatistics;
    private ToolStripButton ActionViewGrid;
    private ToolStripButton ActionViewDecode;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripSeparator toolStripSeparator10;
    private System.Windows.Forms.Timer TimerTooltip;
    private DataGridView GridIterations;
    private BindingSource BindingSourceIterationRow;
    private ToolStripStatusLabel LabelStatusSep3;
    private ToolStripStatusLabel LabelStatusRemaining;
    private ToolStripStatusLabel LabelStatusTimeSubBatch;
    private ToolStripStatusLabel LabelStatusSep4;
    private DataGridViewTextBoxColumn ColumnIteration;
    private DataGridViewTextBoxColumn ColumnRepeatedCount;
    private DataGridViewTextBoxColumn ColumnMaxOccurences;
    private DataGridViewTextBoxColumn ColumnRemainingRate;
    private DataGridViewTextBoxColumn ColumnElapsedCount;
    private DataGridViewTextBoxColumn ColumnElapsedAddition;
  }
}
