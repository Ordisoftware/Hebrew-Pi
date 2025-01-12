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
/// <edited> 2025-01-11 </edited>
namespace Ordisoftware.Hebrew.Pi;

using System;
using System.Diagnostics;
using SQLite;

public partial class MainForm : Form
{

  const string MsgNoDuplicates = "Aucun dupliqué.";
  const string MsgPrefix = "Sur l'échantillon donné, la théorie des répétés ajoutés aux positions";
  const string MsgOk = $"{MsgPrefix} fonctionne.";
  const string MsgNotOk = $"{MsgPrefix} ne fonctionne pas.";
  const string MsgSaved_Fixed = "Les groupes dupliquée ont été corrigés et le fichier reconstruit.";

  public class GroupInfo
  {
    public int Count { get; set; }
    public string Indices { get; set; }
    public GroupInfo(int count, string indices)
    {
      Count = count;
      Indices = indices;
    }
  }

  public enum PiDecimalsExtractSize
  {
    PiDecimals_128K,
    PiDecimals_1M,
    PiDecimals_1B,
    PiDecimals_10B,
    PiDecimals_1M_Fixed,
    PiDecimals_1B_Fixed,
    PiDecimals_10B_Fixed
  }

  private PiDecimalsExtractSize FileName;

  private Dictionary<string, GroupInfo> PiGroups;

  private SQLiteConnection DB;

  private Stopwatch chrono;

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
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(process);
    else
      process();
    //
    void process()
    {
      LabelStatusProgress.Text = message;
      UpdateStatusTime();
    }
  }

  private void UpdateStatusTime()
  {
    if ( StatusStrip.InvokeRequired )
      StatusStrip.Invoke(process);
    else
      process();
    void process()
    {
      LabelStatusTime.Text = chrono.Elapsed.ToString(@"mm\:ss");
    }
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
    string piDecimals = File.ReadAllText(Path.Combine(Globals.DocumentsFolderPath, FileName.ToString()) + ".txt").Trim();
    if ( piDecimals.StartsWith("3.") )
      piDecimals = piDecimals.Substring(2);
    PiGroups = Enumerable
      .Range(0, piDecimals.Length / 10)
      .Select(i => new { Index = i + 1, Group = piDecimals.Substring(i * 10, 10) })
      .GroupBy(x => x.Group)
      .ToDictionary(g => g.Key,
                    g => new GroupInfo(g.Count(),
                                       string.Join(", ", g.Select(x => x.Index))));
    Grid.DataSource = PiGroups
      .Select(kvp => new { Group = kvp.Key, kvp.Value.Count, kvp.Value.Indices })
      .OrderByDescending(item => item.Count)
      .ToList();
  }

  private void ActionCheckDuplicates_Click(object sender, EventArgs e)
  {
    var duplicates = PiGroups.Where(g => g.Value.Count > 1);
    if ( duplicates.Count() == 0 )
      MessageBox.Show(MsgNoDuplicates);
    else
    {
      foreach ( var group in duplicates )
      {
        var decuplet = group.Key;
        foreach ( var index in group.Value.Indices.Split(',').Select(int.Parse) )
        {
          long sum = long.Parse(decuplet) + index;
          if ( PiGroups.ContainsKey(sum.ToString()) )
          {
            MessageBox.Show(MsgNotOk);
            return;
          }
        }
      }
      MessageBox.Show(MsgOk);
      ActionSaveFixedDuplicatesToFile.Enabled = true;
    }
  }

  private void ActionSaveFixedDuplicatesToFile_Click(object sender, EventArgs e)
  {
    var piDecimals = new Dictionary<int, string>();
    foreach ( var group in PiGroups )
    {
      var decuplet = group.Key.PadLeft(10, '0');
      var indices = group.Value.Indices.Split(',').Select(int.Parse).ToList();
      if ( group.Value.Count > 1 )
        foreach ( var index in indices )
          piDecimals[index] = ( long.Parse(decuplet) + index ).ToString("D10");
      else
        foreach ( var index in indices )
          piDecimals[index] = decuplet;
    }
    var indicesOrdered = piDecimals.Keys.OrderBy(index => index).ToList();
    var builder = new StringBuilder();
    foreach ( var index in indicesOrdered )
      builder.Append(piDecimals[index]);
    File.WriteAllText(Path.Combine(Globals.DocumentsFolderPath, FileName.ToString()) + "_Fixed.txt", builder.ToString());
    MessageBox.Show(MsgSaved_Fixed);
  }

  private async void ActionCreateTable_Click(object sender, EventArgs e)
  {
    ActionCreateTable.Enabled = false;
    await Task.Run(() =>
    {
      chrono = new Stopwatch();
      chrono.Start();
      CreateTable(Path.Combine(Globals.DocumentsFolderPath, FileName.ToString()) + ".txt");
      chrono.Stop();
      UpdateStatusTime();
    });
    ActionCreateTable.Enabled = true;
  }

  private async void CreateTable(string fileName)
  {
    string dbPath = Path.Combine(Globals.DatabaseFolderPath, FileName.ToString()) + Globals.DatabaseFileExtension;
    string inputFilePath = fileName;
    int blockSize = 10;
    try
    {
      if ( DB is not null )
      {
        DB.Close();
        DB.Dispose();
      }
      DB = new SQLiteConnection(dbPath);
      DB.CreateTable<DecupletRow>();
      DB.BeginTransaction();
      UpdateStatusInfo($"0k - Started");
      int bufferLength = 10_000_000;
      char[] buffer = new char[bufferLength];
      int charsRead;
      long motif = 0;
      long totalBlocks = 0;
      using var reader = new StreamReader(inputFilePath);
      while ( ( charsRead = reader.Read(buffer, 0, bufferLength) ) > 0 )
      {
        for ( int indexBuffer = 0; indexBuffer < charsRead; indexBuffer += blockSize )
          if ( indexBuffer + blockSize <= charsRead )
          {
            motif = 0;
            for ( int indexMotif = 0; indexMotif < blockSize; indexMotif++ )
              motif = motif * 10 + ( buffer[indexBuffer + indexMotif] - '0' );
            DB.Insert(new DecupletRow { Motif = motif });
            totalBlocks++;
            if ( totalBlocks % 1000000 == 0 )
              UpdateStatusInfo($"{totalBlocks / 1000}k blocs insérés");
          }
      }
      UpdateStatusInfo($"{totalBlocks / 1000}k - Committing");
      DB.Commit();
      UpdateStatusInfo($"{totalBlocks / 1000}k - Indexing");
      DB.Execute($"CREATE INDEX idx_decuplets_value ON {DecupletRow.TableName} ({nameof(DecupletRow.Motif)})");
      UpdateStatusInfo($"{totalBlocks / 1000}k - Finished");
    }
    catch ( Exception ex )
    {
      UpdateStatusInfo($"Error : {ex.Message}");
    }
  }

  private void CreateDataTable()
  {
    try
    {
      var dataTable = new DataTable();
      var command = DB.CreateCommand("SELECT * FROM Decuplets LIMIT 1000000 OFFSET 0");
      var list = command.ExecuteQuery<DecupletRow>();
      if ( list.Count > 0 )
      {
        foreach ( var prop in typeof(DecupletRow).GetProperties() )
          dataTable.Columns.Add(prop.Name);
        foreach ( var row in list )
        {
          var dataRow = dataTable.NewRow();
          foreach ( var prop in typeof(DecupletRow).GetProperties() )
            dataRow[prop.Name] = prop.GetValue(row);
          dataTable.Rows.Add(dataRow);
        }
      }
      Grid.DataSource = dataTable;
    }
    catch ( Exception ex )
    {
      UpdateStatusInfo(ex.Message);
    }

  }

}
