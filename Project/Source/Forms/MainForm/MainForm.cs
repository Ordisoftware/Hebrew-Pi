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
/// <edited> 2025-01-13 </edited>
namespace Ordisoftware.Hebrew.Pi;

using System;
using System.Diagnostics;
using System.IO;
using SQLite;

public partial class MainForm : Form
{

  const string MsgNoRepeated = "Aucun répété.";
  const string MsgPrefix = "Sur l'échantillon donné, la théorie des répétés ajoutés aux positions";
  const string MsgOk = $"{MsgPrefix} fonctionne.";
  const string MsgNotOk = $"{MsgPrefix} ne fonctionne pas.";
  const string MsgSaved_Fixed = "Les groupes dupliquée ont été corrigés et le fichier reconstruit.";

  private Stopwatch chrono;
  private SQLiteConnection DB;
  private string SQLiteTempDir = @"D:\";

  private PiDecimalsExtractSize FileName;
  private Dictionary<string, GroupInfo> PiGroups;

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
    SelectFileName.SelectedIndex = 0;
  }

  private void UpdateStatusInfo(string message)
  {
    void process()
    {
      LabelStatusProgress.Text = message;
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
      LabelStatusTime.Text = chrono.Elapsed.ToString(@"mm\:ss");
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
    FileName = (PiDecimalsExtractSize)SelectFileName.SelectedItem;
  }

  private void ActionLoadFile_Click(object sender, EventArgs e)
  {
    DoActionLoad();
  }

  private void ActionCheckRepeated_Click(object sender, EventArgs e)
  {
    DoActionCheckRepeated();
  }

  private void ActionSaveFixedRepeatedToFile_Click(object sender, EventArgs e)
  {
    DoActionSaveFixedRepeatedToFile();
  }

  private void ActionDbConnect_Click(object sender, EventArgs e)
  {
    if ( DB is not null )
    {
      DB.Close();
      DB.Dispose();
    }
    string dbPath = Path.Combine(Globals.DatabaseFolderPath, FileName.ToString()) + Globals.DatabaseFileExtension;
    DB = new SQLiteConnection(dbPath);
    if ( SQLiteTempDir.Length > 0 )
      DB.Execute($"PRAGMA temp_store_directory = '{SQLiteTempDir}'");
  }

  private async void ActionCreateTable_Click(object sender, EventArgs e)
  {
    await DoActionCreateTable();
  }

  private async void ActionDbBatch_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo("Start reducing repeated adding their position?") )
      await ProcessIterationsAsync(0);
  }

}
