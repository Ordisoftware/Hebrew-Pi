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

using SQLite;

public partial class MainForm : Form
{

  private PiDecimalsExtractSize TextFileName;
  private Dictionary<string, GroupInfo> PiDecuplets;

  private SQLiteConnection DB;
  private string SQLiteTempDir = @"D:\";

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
    }
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(process);
    else
      process();
  }

  private void UpdateStatusTime()
  {
    void process()
    {
      var elapsed = Globals.ChronoProcess.Elapsed;
      List<string> parts = new List<string>();
      if ( elapsed.Days > 0 ) parts.Add($"{elapsed.Days}d");
      if ( elapsed.Hours > 0 ) parts.Add($"{elapsed.Hours}h");
      if ( elapsed.Minutes > 0 ) parts.Add($"{elapsed.Minutes}m");
      if ( elapsed.Seconds > 0 || elapsed.TotalSeconds == 0 ) parts.Add($"{elapsed.Seconds}s");
      LabelStatusTime.Text = parts.Count == 0 ? "0s" : string.Join(" ", parts);
    }
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
    TextFileName = (PiDecimalsExtractSize)SelectFileName.SelectedItem;
  }

  private void ActionFileLoad_Click(object sender, EventArgs e)
  {
    DoActionFileLoad();
  }

  private void ActionFileCheckRepeated_Click(object sender, EventArgs e)
  {
    DoActionFileCheckRepeated();
  }

  private void ActionFileSaveFixedRepeating(object sender, EventArgs e)
  {
    ActionFileSaveFixedRepeating();
  }

  private void ActionDbConnect_Click(object sender, EventArgs e)
  {
    if ( DB is not null )
    {
      DB.Close();
      DB.Dispose();
    }
    string dbPath = Path.Combine(Globals.DatabaseFolderPath, TextFileName.ToString()) + Globals.DatabaseFileExtension;
    DB = new SQLiteConnection(dbPath);
    if ( SQLiteTempDir.Length > 0 )
      DB.Execute($"PRAGMA temp_store_directory = '{SQLiteTempDir}'");
    ActionDbCreate.Enabled = true;
    ActionBatchRun.Enabled = true;
  }

  private async void ActionDbCreate_Click(object sender, EventArgs e)
  {
    //if ( !DisplayManager.QueryYesNo("Delete and create tables?") ) return;
    ActionDbConnect.Enabled = false;
    ActionDbCreate.Enabled = false;
    ActionBatchRun.Enabled = false;
    ClearStatusBar();
    await Task.Run(() =>
    {
      Globals.ChronoProcess.Restart();
      DoActionDbCReate(Path.Combine(Globals.DocumentsFolderPath, TextFileName.ToString()) + ".txt");
      Globals.ChronoProcess.Stop();
      UpdateStatusTime();
    });
    ActionDbCreate.Enabled = true;
    ActionDbConnect.Enabled = true;
    ActionBatchRun.Enabled = true;
  }

  private async void ActionBatchRun_Click(object sender, EventArgs e)
  {
    //if ( !DisplayManager.QueryYesNo("Start reducing repeated adding their position?") ) return;
    ActionDbConnect.Enabled = false;
    ActionDbCreate.Enabled = false;
    ActionBatchRun.Enabled = false;
    ActionStopBatch.Enabled = true;
    Globals.CancelRequired = false;
    ClearStatusBar();
    await Task.Run(() =>
    {
      Globals.ChronoProcess.Restart();
      DoActionBatchRun(0);
      Globals.ChronoProcess.Stop();
      UpdateStatusTime();
    });
    ActionDbCreate.Enabled = true;
    ActionDbConnect.Enabled = true;
    ActionBatchRun.Enabled = true;
    ActionStopBatch.Enabled = false;
  }

  private void ActionBatchStop_Click(object sender, EventArgs e)
  {
    Globals.CancelRequired = true;
    ActionStopBatch.Enabled = false;
  }

}
