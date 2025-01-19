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
/// <created> 2025-01 </created>
/// <edited> 2025-01 </edited>
namespace Ordisoftware.Hebrew.Pi;

/// <summary>
/// Provides decuplet list.
/// </summary>
abstract class DecupletList : IEnumerable<DecupletItem>
{

  private bool Mutex;

  protected readonly List<DecupletItem> Items = [];

  protected readonly string FilePath;

  public int Count => Items.Count;

  public DecupletItem this[int index] => Items[index];

  IEnumerator<DecupletItem> IEnumerable<DecupletItem>.GetEnumerator() => Items.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

  public abstract void Add(DecupletItem decuplet);

  public void Clear()
  {
    Items.Clear();
    Save();
  }

  public void Sort()
  {
    Items.Sort();
    Save();
  }

  public void Load(Action actionAfter)
  {
    Items.Clear();
    if ( !File.Exists(FilePath) ) return;
    try
    {
      foreach ( var item in File.ReadLines(FilePath) )
      {
        var parts = item.Split(',');
        SystemManager.TryCatch(() => Items.Add(new DecupletItem(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]))));
      }
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      actionAfter?.Invoke();
    }
  }

  public void Save()
  {
    if ( Globals.IsLoadingData || Mutex ) return;
    Mutex = true;
    try
    {
      var items = new List<string>();
      foreach ( var item in Items )
        items.Add($"{item.Position},{item.Motif}");
      File.WriteAllLines(FilePath, items);
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      Mutex = false;
    }
  }

  protected DecupletList(string filePath)
  {
    FilePath = filePath;
  }

}
