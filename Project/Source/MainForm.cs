﻿using SQLite;

namespace Ordisoftware.Hebrew.Pi;

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

  PiDecimalsExtractSize FileName = PiDecimalsExtractSize.PiDecimals_10B;

  public MainForm()
  {
    InitializeComponent();
  }

  private Dictionary<string, GroupInfo> PiGroups;

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

  private void ActionCheck_Click(object sender, EventArgs e)
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
      ActionSave.Enabled = true;
    }
  }

  private void ActionSave_Click(object sender, EventArgs e)
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

  private void CompareFiles(string file1, string file2)
  {
    string piDecimals1 = File.ReadAllText(file1).Trim();
    string piDecimals2 = File.ReadAllText(file2).Trim();
    if ( piDecimals1.Length != piDecimals2.Length )
    {
      MessageBox.Show("Les fichiers ont des tailles différentes.");
      return;
    }
    int differences = 0;
    int groupSize = 10;
    for ( int index = 0; index < piDecimals1.Length; index += groupSize )
    {
      string chunk1 = piDecimals1.Substring(index, groupSize);
      string chunk2 = piDecimals2.Substring(index, groupSize);
      if ( chunk1 != chunk2 )
        differences++;
    }
    if ( differences == 0 )
      MessageBox.Show("Les fichiers sont identiques.");
    else
      MessageBox.Show($"Il y a {differences} différences.");
  }

  Stopwatch chrono;

  private async void ActionCreateTable_Click(object sender, EventArgs e)
  {
    await Task.Run(() =>
    {
      chrono = new Stopwatch();
      chrono.Start();
      CreateTable(Path.Combine(Globals.DocumentsFolderPath, FileName.ToString()) + ".txt");
      chrono.Stop();
      UpdateStatusTime();
    });
  }

  private async void CreateTable(string fileName)
  {
    string dbPath = Path.Combine(Globals.DatabaseFolderPath, Globals.ApplicationDatabaseFileName);
    string inputFilePath = fileName;
    int blockSize = 10;
    try
    {
      using var db = new SQLiteConnection(dbPath);
      db.CreateTable<DecupletRow>();
      using var fileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
      using var reader = new StreamReader(fileStream);
      char[] buffer = new char[1024 * 1024];
      int charsRead;
      long totalBlocks = 0;
      db.BeginTransaction();
      while ( ( charsRead = reader.Read(buffer, 0, buffer.Length) ) > 0 )
      {
        string chunk = new string(buffer, 0, charsRead);
        for ( int i = 0; i < chunk.Length; i += blockSize )
          if ( i + blockSize <= chunk.Length )
          {
            db.Insert(new DecupletRow { Value = long.Parse(chunk.Substring(i, blockSize)) });
            totalBlocks++;
            if ( totalBlocks % 100000 == 0 )
              UpdateStatusInfo($"{totalBlocks / 1000}k blocs insérés");
          }
      }
      fileStream.Close();
      UpdateStatusInfo($"{totalBlocks / 1000}k - Committing");
      db.Commit();
      UpdateStatusInfo($"{totalBlocks / 1000}k - Indexing");
      db.Execute("CREATE INDEX idx_decuplets_value ON Decuplets(Value);");
      UpdateStatusInfo($"{totalBlocks / 1000}k - Finished");
    }
    catch ( Exception ex )
    {
      UpdateStatusInfo($"Error : {ex.Message}");
    }
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
    LabelStatusTime.Text = chrono.Elapsed.ToString(@"mm\:ss");
  }

}
