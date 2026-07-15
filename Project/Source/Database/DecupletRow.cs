/// <license>
/// This file is part of Ordisoftware Hebrew Pi.
/// Copyright 2026 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2025-03 </created>
/// <edited> 2025-03 </edited>
namespace Ordisoftware.Hebrew.Pi;

using SQLite;

[Serializable]
[Table(TableName)]
public class DecupletRow
{

  public const string TableName = "Decuplets";

  static public readonly long[] MissingMotifToAdd = [0191295669, 5623831000, 0780255325, 3353406089];

  static public readonly string[] MissingDigitsToAdd = ["69", "00", "25", "89"];

  static public T GetMissingFor100G<T>(string filePathText, T[] list, T defaultValue)
  {
    return filePathText.EndsWith("-1.txt")
      ? list[0]
      : filePathText.EndsWith("-2.txt")
        ? list[1]
        : filePathText.EndsWith("-3.txt")
          ? list[2]
          : filePathText.EndsWith("-4.txt")
            ? list[3]
            : defaultValue;
  }

  static public long GetMissingMotifFor100G(string filePathText)
  {
    return GetMissingFor100G(filePathText, MissingMotifToAdd, -1);
  }

  static public string GetMissingDigitsFor100G(string filePathText)
  {
    return GetMissingFor100G(filePathText, MissingDigitsToAdd, string.Empty);
  }

  [PrimaryKey]
  public long Position { get; set; }

  public long Motif { get; set; }

  //public string Fragments { get; set; }

  //public string Hebrew { get; set; }

  //public string Translation { get; set; }

  //public string Comment { get; set; }

  //public DateTime? DateModified { get; set; }

}
