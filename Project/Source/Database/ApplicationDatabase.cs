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
/// <created> 2025-01-11 </created>
/// <edited> 2025-01-11 </edited>
namespace Ordisoftware.Hebrew.Pi;

using Equin.ApplicationFramework;

[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP006:Implement IDisposable", Justification = "<En attente>")]
sealed partial class ApplicationDatabase : SQLiteDatabase
{

  static public ApplicationDatabase Instance { get; }

  static ApplicationDatabase()
  {
    Instance = new ApplicationDatabase();
  }

  public List<DecupletRow> Decuplets { get; private set; }

  public BindingListView<DecupletRow> DecupletsAsBindingList { get; private set; }

  private ApplicationDatabase() : base(Globals.ApplicationDatabaseFilePath)
  {
  }

  protected override void DoClose()
  {
    if ( Decuplets is null ) return;
    if ( ClearListsOnCloseOrRelease )
      Decuplets?.Clear();
    Decuplets = null;
  }

  protected override void CreateTables()
  {
    Connection.CreateTable<DecupletRow>();
  }

  protected override void DoLoadAll()
  {
    Decuplets = [.. Connection.Table<DecupletRow>()];
  }

  protected override void CreateBindingLists()
  {
    DecupletsAsBindingList?.Dispose();
    DecupletsAsBindingList = new(Decuplets);
  }

  protected override void DoSaveAll()
  {
    CheckAccess(Decuplets, nameof(DecupletRow));
    Connection.UpdateAll(Decuplets);
  }

  public void DeleteAll()
  {
    CheckConnected();
    CheckAccess(Decuplets, nameof(Decuplets));
    Connection.DeleteAll<DecupletRow>();
    Decuplets.Clear();
  }

  protected override bool CreateDataIfNotExist(bool reset = false)
  {
    /* if non empty */
    return false;
    //FillFromFile();
    //return true;
  }

}
