namespace Ordisoftware.Hebrew.PiDecoder;

public partial class MainForm : Form
{

  const string MsgNoDuplicates = "Aucun dupliqué.";
  const string MsgPrefix = "Sur l'échantillon donné, la théorie des répétés ajoutés aux positions";
  const string MsgOk = $"{MsgPrefix} fonctionne.";
  const string MsgNotOk = $"{MsgPrefix} ne fonctionne pas.";
  const string MsgSavedCorrected = "Les groupes dupliquée ont été corrigés et le fichier reconstruit.";

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

  public enum FileSizeType
  {
    GDPI120K,
    GDPI1M,
    GDPI1B,
    GDPI1MCorrected,
    GDPI1BCorrected
  }

  FileSizeType FileName = FileSizeType.GDPI1B;

  public MainForm()
  {
    InitializeComponent();
  }

  private Dictionary<string, GroupInfo> PiGroups;

  private void MainForm_Load(object sender, EventArgs e)
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
    File.WriteAllText(Path.Combine(Globals.DocumentsFolderPath, FileName.ToString()) + "Corrected.txt", builder.ToString());
    MessageBox.Show(MsgSavedCorrected);
  }

  private void ComparePiDecimals(string file1, string file2)
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

}
