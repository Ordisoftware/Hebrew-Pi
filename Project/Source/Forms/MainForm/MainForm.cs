﻿/// <license>
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
partial class MainForm : Form
{

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
    ColumnIteration.HeaderText = "Itération";
    ColumnAllRepeatingCount.HeaderText = "Total Reps";
    ColumnRepeatingRate.HeaderText = "Taux";
    ColumnUniqueRepeatingCount.HeaderText = "Uniques Reps";
    ColumnMaxOccurences.HeaderText = "Max";
    ColumnRemainingRate.HeaderText = "Restants";
    ColumnElapsedCounting.HeaderText = "Comptage";
    ColumnElapsedAdding.HeaderText = "Additions";
  }

  private void MainForm_Load(object sender, EventArgs e)
  {
    DoFormLoad(sender, e);
    TimerMemory_Tick(null, null);
    InitializeListBoxPiDecimals();
    InitializeListBoxCacheSize();
    InitializeComboBoxSqlHelper();
  }

  const ulong MemorySizeInKiB = 1024;
  const ulong MemorySizeInMiB = MemorySizeInKiB * 1024;
  const ulong MemorySizeInGiB = MemorySizeInMiB * 1024;

  private void InitializeComboBoxSqlHelper()
  {
    SelectSqlHelper.Items.AddRange(SqlHelperList);
    SelectSqlHelper.SelectedIndex = 1;
  }

  private void InitializeListBoxPiDecimals()
  {
    foreach ( string file in Directory.GetFiles(Path.Combine(Globals.DocumentsFolderPath, "PiDecimals"), "PiDecimals*.txt") )
      SelectPiDecimalsFile.Items.Add(file);
    SelectPiDecimalsFile.SelectedIndex = 2;
  }

  private void InitializeListBoxCacheSize()
  {
    int memTotal = (int)( SystemManager.TotalVisibleMemoryValue / MemorySizeInGiB );
    int memFree = (int)( SystemManager.PhysicalMemoryFreeValue / MemorySizeInGiB );
    int indexList = 0;
    for ( int indexStep = 0; indexStep < memTotal * 70 / 100; indexStep += 2 )
    {
      SelectDbCache.Items.Add(indexStep);
      if ( indexStep <= memFree ) indexList++;
    }
    SelectDbCache.SelectedIndex = indexList / 4;
  }

  private void MainForm_Shown(object sender, EventArgs e)
  {
    DoFormShown(sender, e);
  }

  private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    DoFormClosing(sender, e);
  }

  private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    DoFormClosed(sender, e);
  }

  private void ActionExit_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void ActionExit_MouseUp(object sender, MouseEventArgs e)
  {
    if ( e.Button == MouseButtons.Right )
      ActionExit_Click(ActionExit, null);
  }

  internal void EditScreenPosition_Click(object sender, EventArgs e)
  {
    DoScreenPosition(sender, e);
  }

  private void ActionResetWinSettings_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToRestoreWindowPosition.GetLang()) )
      Settings.RestoreMainForm();
  }

  private void ActionShowKeyboardNotice_Click(object sender, EventArgs e)
  {
    Globals.KeyboardShortcutsNotice?.Popup();
  }

  internal void EditDialogBoxesSettings_CheckedChanged(object sender, EventArgs e)
  {
    Settings.SoundsEnabled = EditSoundsEnabled.Checked;
    DisplayManager.AdvancedFormUseSounds = EditSoundsEnabled.Checked;
    DisplayManager.FormStyle = EditUseAdvancedDialogBoxes.Checked
      ? MessageBoxFormStyle.Advanced
      : MessageBoxFormStyle.System;
    DisplayManager.IconStyle = DisplayManager.FormStyle switch
    {
      MessageBoxFormStyle.System => EditSoundsEnabled.Checked
                                    ? MessageBoxIconStyle.ForceInformation
                                    : MessageBoxIconStyle.ForceNone,
      MessageBoxFormStyle.Advanced => MessageBoxIconStyle.ForceInformation,
      _ => throw new AdvNotImplementedException(DisplayManager.FormStyle),
    };
  }

  private void EditShowSuccessDialogs_CheckStateChanged(object sender, EventArgs e)
  {
    Settings.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
    DisplayManager.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
  }

  private void ActionPreferences_Click(object sender, EventArgs e)
  {
    bool temp = Globals.IsReadOnly;
    try
    {
      Globals.IsReadOnly = true;
      //PreferencesForm.Run();
      InitializeSpecialMenus();
      InitializeDialogsDirectory();
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      Globals.IsReadOnly = temp;
    }
  }

  private void ActionViewDecode_Click(object sender, EventArgs e)
  {
    SetView(ViewMode.Decode);
  }

  private void ActionViewGrid_Click(object sender, EventArgs e)
  {
    SetView(ViewMode.Grid);
  }

  private void ActionViewManage_Click(object sender, EventArgs e)
  {
    SetView(ViewMode.Manage);
  }

  public void ActionWebCheckUpdate_Click(object sender, EventArgs e)
  {
    var lastdone = Settings.CheckUpdateLastDone;
    bool exit = WebCheckUpdate.Run(ref lastdone,
                                   Settings.CheckUpdateAtStartupDaysInterval,
                                   e is null,
                                   Settings.CheckUpdateAtStartup);
    Settings.CheckUpdateLastDone = lastdone;
    if ( exit ) Close();
  }

  public void ActionViewLog_Click(object sender, EventArgs e)
  {
    DebugManager.TraceForm.Popup();
  }

  public void ActionViewStats_Click(object sender, EventArgs e)
  {
    StatisticsForm.Run();
  }

  private void ActionDatabaseSetCacheSize_Click(object sender, EventArgs e)
  {
    // TODO
  }

  private void NotifyIcon_Click(object sender, EventArgs e)
  {
    if ( Visible )
    {
      Hide();
    }
    else
    {
      this.Popup();
    }
  }

  private void TimerMemory_Tick(object sender, EventArgs e)
  {
    DoTimerMemory();
  }

  private void TimerStatus_Tick(object sender, EventArgs e)
  {
    DoTimerStatus();
  }

  private void EditAllowInterruption_CheckedChanged(object sender, EventArgs e)
  {
    CanForceTerminateBatch = EditAllowInterruption.Checked;
  }

  private void SelectSqlHelper_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = e.Value.GetType().Name;
  }

  private void SelectSqlHelper_SelectedIndexChanged(object sender, EventArgs e)
  {
    SqlHelper = (ReduceRepeatingBase)SelectSqlHelper.SelectedItem;
  }

  private void SelectDbCache_SelectedIndexChanged(object sender, EventArgs e)
  {
    SetDbCache();
  }

  private async void SetDbCache()
  {
    SelectDbCache.Invoke(() => DB?.SetCacheSize((int)SelectDbCache.SelectedItem * (int)MemorySizeInMiB, NameWorkingDB));
  }

  private void ActionDbNew_Click(object sender, EventArgs e)
  {
    if ( SaveFileDialogDB.ShowDialog() == DialogResult.OK )
    {
      if ( File.Exists(SaveFileDialogDB.FileName) )
        File.Delete(SaveFileDialogDB.FileName);
      DoBatchAsync(() => DoActionDbOpenAsync(SaveFileDialogDB.FileName));
    }
  }

  private void ActionDbOpen_Click(object sender, EventArgs e)
  {
    if ( OpenFileDialogDB.ShowDialog() == DialogResult.OK )
      DoBatchAsync(() => DoActionDbOpenAsync(OpenFileDialogDB.FileName));
  }

  private void ActionDbClose_Click(object sender, EventArgs e)
  {
    DoBatchAsync(() => DoActionDbCloseAsync());
  }

  private void ActionCreateData_Click(object sender, EventArgs e)
  {
    string filePathText = SelectPiDecimalsFile.SelectedItem.ToString();
    DoBatchAsync(() => DoActionPopulateAsync(filePathText));
  }

  private void ActionCreateIndex_Click(object sender, EventArgs e)
  {
    DoBatchAsync(() => DoCreateIndexAsync(), false);
  }

  private void ActionNormalize_Click(object sender, EventArgs e)
  {
    DoBatchAsync(() => DoActionReduceRepeatingAsync());
  }

  private void ActionStop_Click(object sender, EventArgs e)
  {
    DoActionStop();
  }

  private void ActionPauseContinue_Click(object sender, EventArgs e)
  {
    DoActionPauseContinue();
  }

  private void SelectPiDecimalsFile_SelectedIndexChanged(object sender, EventArgs e)
  {
    string path = SelectPiDecimalsFile.SelectedItem.ToString();
    long size = SystemManager.GetFileSize(path);
    char[] buffer = new char[2];
    using var reader = new StreamReader(path);
    if ( reader.Read(buffer, 0, 2) == 2 )
    {
      string str = new(buffer, 0, 2);
      if ( str == "3." || str == "3," ) size -= 2;
    }
    PiDecimalsFileSize = size;
    ActionFixDigitsMissingIn100GB.Enabled = size == 99999999998;
    EditMaxMotifs.Value = size / 10;
  }

  private void SelectPiDecimalsFile_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = Path.GetFileNameWithoutExtension(e.Value.ToString());
  }

  private void GridIterations_Leave(object sender, EventArgs e)
  {
    GridIterations.ClearSelection();
  }

  private void GridIterations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
  {
    if ( e.Value is null )
      e.Value = "?";
    else
    {
      if ( e.ColumnIndex == ColumnAllRepeatingCount.Index || e.ColumnIndex == ColumnUniqueRepeatingCount.Index )
        e.Value = ( (long)e.Value ).ToString("N0");
      else
      if ( e.ColumnIndex == ColumnMaxOccurences.Index )
      {
        var value = (long)e.Value;
        e.Value = value != 0 ? $"x{value}" : string.Empty;
      }
      else
      if ( e.ColumnIndex == ColumnRepeatingRate.Index || e.ColumnIndex == ColumnRemainingRate.Index )
        e.Value = ( (double)e.Value ).ToString("0.00") + "%";
      else
      if ( e.ColumnIndex == ColumnElapsedCounting.Index || e.ColumnIndex == ColumnElapsedAdding.Index )
      {
        var value = (TimeSpan)e.Value;
        if ( value != TimeSpan.Zero )
          e.Value = value.AsReadable();
        else
          e.Value = string.Empty;
      }
    }
  }

  private void ActionSquare_Click(object sender, EventArgs e)
  {
    foreach ( var row in DB.Query<DecupletRow>("select * from Decuplets limit 0, 10") )
      textBox1.AppendText(row.Motif.ToString() + Environment.NewLine);
  }

  private void ActionFixDigitsMissingIn100GB_Click(object sender, EventArgs e)
  {
    string charactersToAdd = "69";
    string filePathText = SelectPiDecimalsFile.SelectedItem.ToString();
    var encoding = SystemManager.GetTextFileEncoding(filePathText);
    using var fs = new FileStream(filePathText, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
    using var writer = new StreamWriter(fs, encoding);
    fs.Seek(0, SeekOrigin.End);
    writer.Write(charactersToAdd);
    writer.Close();
    fs.Close();
    SelectPiDecimalsFile_SelectedIndexChanged(null, null);
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

  //private void CreateDataTable()
  //{
  //  try
  //  {
  //    var dataTable = new DataTable();
  //    var command = DB.CreateCommand("SELECT * FROM Decuplets LIMIT 1000000 OFFSET 0");
  //    var list = command.ExecuteQuery<DecupletRow>();
  //    if ( list.Count > 0 )
  //    {
  //      foreach ( var prop in typeof(DecupletRow).GetProperties() )
  //        dataTable.Columns.Add(prop.Name);
  //      foreach ( var row in list )
  //      {
  //        var dataRow = dataTable.NewRow();
  //        foreach ( var prop in typeof(DecupletRow).GetProperties() )
  //          dataRow[prop.Name] = prop.GetValue(row);
  //        dataTable.Rows.Add(dataRow);
  //      }
  //    }
  //    Grid.DataSource = dataTable;
  //  }
  //  catch ( Exception ex )
  //  {
  //    UpdateStatusInfo(ex.Message);
  //  }
  //}

}
