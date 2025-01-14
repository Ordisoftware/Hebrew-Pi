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
/// <created> 2025-01-10 </created>
/// <edited> 2025-01-14 </edited>
namespace Ordisoftware.Hebrew.Pi;

public partial class MainForm : Form
{

  //private Dictionary<string, GroupInfo> PiDecuplets;

  private PiDecimalsExtractSize PiDecimalsExtract;
  private string SQLiteTempDir = @"D:\";
  private ApplicationDatabase DB;

  #region Singleton

  /// <summary>
  /// Indicates the singleton instance.
  /// </summary>
  static internal MainForm Instance { get; private set; }

  /// <summary>
  /// Static constructor.
  /// </summary>
  static MainForm()
  {
    Instance = new MainForm();
  }

  #endregion

  public MainForm()
  {
    InitializeComponent();
    foreach ( var value in Enums.GetValues<PiDecimalsExtractSize>() )
      SelectFileName.Items.Add(value);
    SelectFileName.SelectedIndex = 3;
    DisplayManager.AdvancedFormUseSounds = false;
    ClearStatusBar();
  }

  private void UpdateButtons()
  {
    void process()
    {
      bool dbOpened = DB is not null;
      SelectFileName.Enabled = !dbOpened;
      ActionDbOpen.Enabled = !dbOpened && SelectFileName.SelectedIndex != -1;
      ActionDbClose.Enabled = dbOpened;
      ActionDbCreateData.Enabled = dbOpened && !Globals.IsInProcess;
      ActionBatchRun.Enabled = dbOpened && !Globals.IsInProcess;
      ActionBatchStop.Enabled = dbOpened && Globals.IsInProcess;
      ActionBatchPause.Enabled = dbOpened && Globals.IsInProcess;
      if ( !ActionBatchPause.Enabled ) ;
    }
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(process);
    else
      process();
  }

  private void ClearStatusBar()
  {
    LabelStatusTime.Text = "-";
    LabelStatusIteration.Text = "-";
    LabelStatusInfo.Text = "-";
  }

  private void UpdateStatusProgress(string text)
  {
    UpdateStatusLabel(LabelStatusIteration, text);
  }

  private void UpdateStatusInfo(string text)
  {
    UpdateStatusLabel(LabelStatusInfo, text);
  }

  private void UpdateStatusLabel(ToolStripStatusLabel label, string text)
  {
    void process()
    {
      label.Text = text;
      UpdateStatusTime();
      StatusStrip.Refresh();
    }
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(process);
    else
      process();
  }

  private void UpdateStatusTime()
  {
    void process() => LabelStatusTime.Text = Globals.ChronoProcess.Elapsed.AsReadable();
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(process);
    else
      process();
  }

  private void Grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
  {
    using var brush = new SolidBrush(Grid.RowHeadersDefaultCellStyle.ForeColor);
    e.Graphics.DrawString(( e.RowIndex + 1 ).ToString(),
                          e.InheritedRowStyle.Font,
                          brush,
                          e.RowBounds.Location.X + 10,
                          e.RowBounds.Location.Y + 4);
  }

  private void Grid_KeyDown(object sender, KeyEventArgs e)
  {
    if ( e.Control && e.KeyCode == Keys.C && Grid.SelectedCells.Count > 0 )
    {
      var builder = new StringBuilder();
      foreach ( DataGridViewCell cell in Grid.SelectedCells )
      {
        builder.Append(cell.Value.ToString());
        if ( cell.ColumnIndex == Grid.Columns.Count - 1 )
          builder.AppendLine();
        else
          builder.Append("\t");
      }
      Clipboard.SetText(builder.ToString());
    }
  }

  private void SelectFileName_SelectedIndexChanged(object sender, EventArgs e)
  {
    PiDecimalsExtract = (PiDecimalsExtractSize)SelectFileName.SelectedItem;
    UpdateButtons();
  }

  private void ActionDbOpen_Click(object sender, EventArgs e)
  {
    string dbPath = Path.Combine(Globals.DatabaseFolderPath, PiDecimalsExtract.ToString()) + Globals.DatabaseFileExtension;
    DB = new ApplicationDatabase(dbPath);
    DB.Open();
    if ( SQLiteTempDir.Length > 0 )
      DB.Connection.SetTempDir(SQLiteTempDir);
    ActionDbCreateData.Enabled = true;
    ActionBatchRun.Enabled = true;
    UpdateButtons();
  }

  private void ActionDbClose_Click(object sender, EventArgs e)
  {
    if ( DB is null ) return;
    DB.Close();
    DB.Dispose();
    DB = null;
    UpdateButtons();
  }

  private async void ActionDbCreateData_Click(object sender, EventArgs e)
  {
    //if ( !DisplayManager.QueryYesNo("Delete and create tables?") ) return;
    ClearStatusBar();
    await Task.Run(async () =>
    {
      try
      {
        Globals.IsInProcess = true;
        UpdateButtons();
        Globals.ChronoProcess.Restart();
        await DoActionDbCreateData(Path.Combine(Globals.DocumentsFolderPath, PiDecimalsExtract.ToString()) + ".txt");
        Globals.ChronoProcess.Stop();
        UpdateStatusTime();
      }
      finally
      {
        Globals.IsInProcess = false;
        UpdateButtons();
      }
    });
  }

  private async void ActionBatchRun_Click(object sender, EventArgs e)
  {
    //if ( !DisplayManager.QueryYesNo("Start reducing repeated adding their position?") ) return;
    ClearStatusBar();
    await Task.Run(async () =>
    {
      try
      {
        Globals.IsInProcess = true;
        UpdateButtons();
        Globals.ChronoProcess.Restart();
        DoActionBatchRun(0);
        Globals.ChronoProcess.Stop();
        UpdateStatusTime();
      }
      finally
      {
        Globals.IsInProcess = false;
        UpdateButtons();
      }
    });
  }

  private void ActionBatchStop_Click(object sender, EventArgs e)
  {
    Globals.CancelRequired = true;
    ActionBatchStop.Enabled = false;
  }

  private void ActionBatchPause_Click(object sender, EventArgs e)
  {
    Globals.PauseRequired = !Globals.PauseRequired;
    UpdateButtons();
    if ( Globals.PauseRequired )
    {
      Globals.ChronoProcess.Stop();
      ActionBatchPause.Text = "Continue";
    }
    else
    {
      ActionBatchPause.Text = "Pause";
      Globals.ChronoProcess.Start();
    }
  }
}
