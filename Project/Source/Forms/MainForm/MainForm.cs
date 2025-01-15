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
/// <edited> 2025-01-15 </edited>
namespace Ordisoftware.Hebrew.Pi;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm : Form
{

  internal SQLiteNetORM DB { get; private set; }

  private string SQLiteTempDir = @"D:\";

  private PiFirstDecimalsLenght PiFirstDecimalsCount;

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
    DoConstructor();
  }

  private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    DoFormClosing(sender, e);
  }

  private void TimerBatch_Tick(object sender, EventArgs e)
  {
    LabelStatusTime.Text = Globals.ChronoBatch.Elapsed.AsReadable();
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

  private async Task<bool> CheckIfBatchCanContinue()
  {
    if ( Globals.CancelRequired ) return false;
    while ( Globals.PauseRequired && !Globals.CancelRequired )
      await Task.Delay(500);
    return true;
  }

  //private void Grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
  //{
  //  using var brush = new SolidBrush(Grid.RowHeadersDefaultCellStyle.ForeColor);
  //  e.Graphics.DrawString(( e.RowIndex + 1 ).ToString(),
  //                        e.InheritedRowStyle.Font,
  //                        brush,
  //                        e.RowBounds.Location.X + 10,
  //                        e.RowBounds.Location.Y + 4);
  //}

  //private void Grid_KeyDown(object sender, KeyEventArgs e)
  //{
  //  if ( e.Control && e.KeyCode == Keys.C && Grid.SelectedCells.Count > 0 )
  //  {
  //    var builder = new StringBuilder();
  //    foreach ( DataGridViewCell cell in Grid.SelectedCells )
  //    {
  //      builder.Append(cell.Value.ToString());
  //      if ( cell.ColumnIndex == Grid.Columns.Count - 1 )
  //        builder.AppendLine();
  //      else
  //        builder.Append("\t");
  //    }
  //    Clipboard.SetText(builder.ToString());
  //  }
  //}

  private void SelectFileName_SelectedIndexChanged(object sender, EventArgs e)
  {
    PiFirstDecimalsCount = (PiFirstDecimalsLenght)SelectFileName.SelectedItem;
    UpdateButtons();
  }

  private void SelectDbCache_SelectedIndexChanged(object sender, EventArgs e)
  {
    SetDbCache();
  }

  private void SetDbCache()
  {
    if ( DB is not null && int.TryParse(SelectDbCache.SelectedItem?.ToString(), out var value) )
    {
      value = value == 0 ? 8192 : value * 1024 * 1024;
      DB.Execute($"PRAGMA cache_size = -{value};");
    }
  }

  private void ActionDbOpen_Click(object sender, EventArgs e)
  {
    string dbPath = Path.Combine(Globals.DatabaseFolderPath, PiFirstDecimalsCount.ToString()) + Globals.DatabaseFileExtension;
    DB = new SQLiteNetORM(dbPath);
    if ( SQLiteTempDir.Length > 0 )
      DB.SetTempDir(SQLiteTempDir);
    DB.CreateTable<DecupletRow>();
    DB.CreateTable<IterationRow>();
    SetDbCache();
    //OFF
    //PRAGMA journal_mode = OFF;
    //PRAGMA synchronous = OFF;
    //PRAGMA locking_mode = EXCLUSIVE;
    //ON
    //PRAGMA journal_mode = DELETE;
    //PRAGMA synchronous = FULL;

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

  private void ActionBatchStop_Click(object sender, EventArgs e)
  {
    Globals.CancelRequired = true;
  }

  private void ActionBatchPause_Click(object sender, EventArgs e)
  {
    Globals.PauseRequired = !Globals.PauseRequired;
    UpdateButtons();
    if ( Globals.PauseRequired )
      Globals.ChronoBatch.Stop();
    else
      Globals.ChronoBatch.Start();
  }

  private async void ActionDbCreateData_Click(object sender, EventArgs e)
  {
    //if ( !DisplayManager.QueryYesNo("Empty and create data?") ) return;
    string fileName = Path.Combine(Globals.DocumentsFolderPath, PiFirstDecimalsCount.ToString()) + ".txt";
    DoBatch(() => DoActionDbCreateData(fileName));
  }

  private async void ActionBatchRun_Click(object sender, EventArgs e)
  {
    //if ( !DisplayManager.QueryYesNo("Start reducing repeating motifs?") ) return;
    DoBatch(() => DoActionBatchRun(0));
  }

  private void MainForm_Load(object sender, EventArgs e)
  {
    DoFormLoad(sender, e);
  }

  private void MainForm_Shown(object sender, EventArgs e)
  {
    DoFormShown(sender, e);
  }

  private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    DoFormClosed(sender, e);
  }
}
