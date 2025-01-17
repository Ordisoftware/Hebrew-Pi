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
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  /// <summary>
  /// Indicates the default Settings instance.
  /// </summary>
  private readonly Properties.Settings Settings = Program.Settings;

  /// <summary>
  /// Indicates previous each paging position.
  /// </summary>
  private int PreviousSeachPagingPosition = -1;

  /// <summary>
  /// Indicates bookmark menu item first index.
  /// </summary>
  private int BookmarkMenuIndex;

  /// <summary>
  /// Indicates history menu item first index.
  /// </summary>
  private int HistoryIndexMenu;

  /// <summary>
  /// Indicates the bookmarks.
  /// </summary>
  private Bookmarks BookmarkItems;

  /// <summary>
  /// Indicates the history.
  /// </summary>
  private History HistoryItems;

  /// <summary>
  /// Indicates the search results.
  /// </summary>
  //private IEnumerable<ReferenceItem> SearchResults;

  /// <summary>
  /// Indicates the number of search results.
  /// </summary>
  public int SearchResultsCount { get; private set; }

  /// <summary>
  /// Indicates the paging count disable form.
  /// </summary>
  private readonly int PagingCountDisableForm = 50;

  /// <summary>
  /// Indicates the current paging.
  /// </summary>
  private int PagingCurrent;

  /// <summary>
  /// Indicates the paging count.
  /// </summary>
  private int PagingCount;

  static public readonly string SearchSeparatorString = ",";

  static public readonly char SearchSeparatorChar = ',';

  /// <summary>
  /// Indicates the hebrew font 12.
  /// </summary>
  private readonly Font HebrewFont12 = new("Hebrew", 12f);

  /// <summary>
  /// Indicates the latin font 10.
  /// </summary>
  private readonly Font LatinFont10 = new("Verdana", 10f);

  /// <summary>
  /// The latin font 8.
  /// </summary>
  private readonly Font LatinFont8 = new("Verdana", 8f);

}
