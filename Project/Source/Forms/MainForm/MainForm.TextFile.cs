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

//public partial class MainForm
//{

//  private void DoActionFileLoad()
//  {
//    string piDecimals = File.ReadAllText(Path.Combine(Globals.DocumentsFolderPath, TextFileName.ToString()) + ".txt").Trim();
//    if ( piDecimals.StartsWith("3.") )
//      piDecimals = piDecimals.Substring(2);
//    PiDecuplets = Enumerable
//      .Range(0, piDecimals.Length / 10)
//      .Select(i => new { Index = i + 1, Group = piDecimals.Substring(i * 10, 10) })
//      .GroupBy(x => x.Group)
//      .ToDictionary(g => g.Key,
//                    g => new GroupInfo(g.Count(),
//                                       string.Join(", ", g.Select(x => x.Index))));
//    Grid.DataSource = PiDecuplets
//      .Select(kvp => new { Group = kvp.Key, kvp.Value.Count, kvp.Value.Indices })
//      .OrderByDescending(item => item.Count)
//      .ToList();
//  }

//  private void DoActionFileCheckRepeated()
//  {
//    var duplicates = PiDecuplets.Where(g => g.Value.Count > 1);
//    if ( duplicates.Count() == 0 )
//      MessageBox.Show(File_NoRepeatedText);
//    else
//    {
//      foreach ( var group in duplicates )
//      {
//        var decuplet = group.Key;
//        foreach ( var index in group.Value.Indices.Split(',').Select(int.Parse) )
//        {
//          long sum = long.Parse(decuplet) + index;
//          if ( PiDecuplets.ContainsKey(sum.ToString()) )
//          {
//            MessageBox.Show(File_NotOkText);
//            return;
//          }
//        }
//      }
//      MessageBox.Show(File_OkText);
//    }
//  }

//  private void ActionFileSaveFixedRepeating()
//  {
//    var piDecimals = new Dictionary<int, string>();
//    foreach ( var group in PiDecuplets )
//    {
//      var decuplet = group.Key.PadLeft(10, '0');
//      var indices = group.Value.Indices.Split(',').Select(int.Parse).ToList();
//      if ( group.Value.Count > 1 )
//        foreach ( var index in indices )
//          piDecimals[index] = ( long.Parse(decuplet) + index ).ToString("D10");
//      else
//        foreach ( var index in indices )
//          piDecimals[index] = decuplet;
//    }
//    var indicesOrdered = piDecimals.Keys.OrderBy(index => index).ToList();
//    var builder = new StringBuilder();
//    foreach ( var index in indicesOrdered )
//      builder.Append(piDecimals[index]);
//    File.WriteAllText(Path.Combine(Globals.DocumentsFolderPath, TextFileName.ToString()) + "_Fixed.txt", builder.ToString());
//    MessageBox.Show(File_SavedFixedText);
//  }

//}
