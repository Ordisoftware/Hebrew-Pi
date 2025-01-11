using SQLite;

namespace Ordisoftware.Hebrew.Pi;

[Serializable]
[Table("Decuplets")]
public class DecupletRow
{

  [PrimaryKey, AutoIncrement]
  public long Index { get; set; }

  //[Indexed]
  public long Value { get; set; }

}
