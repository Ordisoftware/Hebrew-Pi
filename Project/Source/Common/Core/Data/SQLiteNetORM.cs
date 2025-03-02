﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2025-01 </edited>
namespace Ordisoftware.Core;

using System;
using System.Runtime.CompilerServices;
using MoreLinq;
using SQLite;

/// <summary>
/// Provides specialized SQLiteConnection.
/// </summary>
public class SQLiteNetORM : SQLiteConnection
{

  /// <summary>
  /// Indicates the database engine name and version.
  /// </summary>
  static public string EngineNameAndVersion { get; private set; }
    = SysTranslations.NothingSlot.GetLang().TrimFirstLast().Titleize();

  /// <summary>
  /// Indicates the provider name.
  /// </summary>
  static public string ProviderName { get; private set; }
    = SysTranslations.NothingSlot.GetLang().TrimFirstLast().Titleize();

  static public int DefaultOptimizeDaysInterval { get; set; }
    = Globals.DaysOfWeekCount;

  public SQLiteNetORM(SQLiteConnectionString connectionString)
    : base(connectionString) { }

  public SQLiteNetORM(string databasePath, bool storeDateTimeAsTicks = true)
    : base(databasePath, storeDateTimeAsTicks) { }

  public SQLiteNetORM(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true)
    : base(databasePath, openFlags, storeDateTimeAsTicks) { }

  public string GetClassAndMethodName([CallerMemberName] string methodName = "")
    => $"{GetType().Name}.{methodName}";

  /// <summary>
  /// Gets a single line of a string.
  /// </summary>
  public string UnFormatSQL(string sql)
  {
    return sql.SplitNoEmptyLines().Select(line => line.Trim()).AsMultiSpace();
  }

  /// <summary>
  /// Returns true if only one instance of the process is running else false.
  /// </summary>
  /// <param name="silent">True if no message is shown else shown.</param>
  public bool CheckProcessConcurrency(bool silent = false)
  {
    var list = Process.GetProcessesByName(Globals.ProcessName);
    bool valid = list.Length == 1;
    if ( !valid && !silent )
      DisplayManager.ShowWarning(SysTranslations.DatabaseNoProcessConcurrency.GetLang());
    return valid;
  }

  /// <summary>
  /// Gets the version of the engine.
  /// </summary>
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  public void InitializeVersion()
  {
    ProviderName = GetType().Name;
    int vernum = LibVersionNumber;
    if ( vernum == -1 )
      EngineNameAndVersion = SysTranslations.UnknownSlot.GetLang();
    else
    {
      string version = vernum.ToString();
      string build = int.Parse(new string([.. version.TakeLast(3)])).ToString();
      string minor = int.Parse(new string([.. version.SkipLast(3).TakeLast(3)])).ToString();
      string major = int.Parse(new string([.. version.SkipLast(6)])).ToString();
      EngineNameAndVersion = $"SQLite {major}.{minor}.{build}";
    }
  }

  /// <summary>
  /// Optimizes the database.
  /// </summary>
  /// <param name="lastDone">The last done date.</param>
  /// <param name="interval">Days interval to check.</param>
  /// <param name="force">True to force check.</param>
  /// <returns>The new date if done else lastDone.</returns>
  public DateTime Optimize(DateTime lastDone, int interval = -1, bool force = false)
  {
    if ( interval == -1 ) interval = DefaultOptimizeDaysInterval;
    if ( force || lastDone.AddDays(interval) < DateTime.Now )
    {
      CheckIntegrity();
      Vacuum();
      lastDone = DateTime.Now;
    }
    return lastDone;
  }

  /// <summary>
  /// Checks the database integrity.
  /// </summary>
  public void CheckIntegrity()
  {
    SystemManager.TryCatchManage(() =>
    {
      string result = ExecuteScalar<string>("SELECT integrity_check FROM pragma_integrity_check()");
      if ( result != "ok" )
      {
        throw new AdvSQLiteException(SysTranslations.DatabaseIntegrityError.GetLang(result));
      }
    });
  }

  /// <summary>
  /// Does the database Vacuum.
  /// </summary>
  public void Vacuum()
  {
    try
    {
      Execute("VACUUM");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.DatabaseVacuumError.GetLang(), ex);
    }
  }

  /// <summary>
  /// Sets the database temp dir.
  /// </summary>
  public void SetTempDir(string path, string attached = null)
  {
    try
    {
      Execute($"PRAGMA temp_store_directory = '{path}'");
      if ( attached is not null ) Execute($"PRAGMA {attached}.temp_store_directory = '{path}'");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  /// <summary>
  /// Sets the database cache dir in KB, 0 for default 8192.
  /// </summary>
  public void SetCacheSize(long size, string attached = null)
  {
    try
    {
      Execute($"PRAGMA cache_size = -{( size == 0 ? 8192 : size )};");
      if ( attached is not null ) Execute($"PRAGMA {attached}.cache_size = -{( size == 0 ? 8192 : size )};");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  public void SetTempStore(SQLiteTempStoreMode mode, string attached = null)
  {
    try
    {
      Execute($"PRAGMA temp_store = {mode};");
      if ( attached is not null ) Execute($"PRAGMA {attached}.temp_store = {mode};");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  public void SetCacheSpill(bool enabled, string attached = null)
  {
    try
    {
      Execute($"PRAGMA cache_spill = {Convert.ToInt32(enabled)};");
      if ( attached is not null ) Execute($"PRAGMA {attached}.cache_spill = {Convert.ToInt32(enabled)};");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  public void SetLocking(SQLiteLockingMode mode, string attached = null)
  {
    try
    {
      Execute($"PRAGMA locking_mode = {mode};");
      if ( attached is not null ) Execute($"PRAGMA {attached}.locking_mode = {mode};");
    }
    catch ( SQLiteException ex ) when ( ex.Message == "not an error" )
    {
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  public void SetSynchronous(SQLiteSynchronousMode mode, string attached = null)
  {
    try
    {
      Execute($"PRAGMA synchronous = {mode};");
      if ( attached is not null ) Execute($"PRAGMA {attached}.synchronous = {mode};");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  public void SetJournal(SQLiteJournalMode mode, string attached = null)
  {
    try
    {
      Execute($"PRAGMA journal_mode = {mode};");
      if ( attached is not null ) Execute($"PRAGMA {attached}.journal_mode = {mode};");
    }
    catch ( SQLiteException ex ) when ( ex.Message == "not an error" )
    {
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  public void SetPageSize(SQLitePageSize mode, string attached = null)
  {
    try
    {
      Execute($"PRAGMA page_size = {(int)mode};");
      if ( attached is not null ) Execute($"PRAGMA {attached}.page_size = {(int)mode};");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

  /// <summary>
  /// Drops a table if exists.
  /// </summary>
  public void DropTableIfExists(string table)
  {
    if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));
    try
    {
      Execute($"DROP TABLE IF EXISTS {table}");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.DBDropTableError.GetLang(table), ex);
    }
  }

  /// <summary>
  /// Renames a table if exists.
  /// </summary>
  /// <param name="tableOldName">Old name.</param>
  /// <param name="tableNewName">New name.</param>
  public void RenameTableIfExists(string tableOldName, string tableNewName)
  {
    if ( tableOldName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(tableOldName));
    if ( tableNewName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(tableNewName));
    try
    {
      Execute($"ALTER TABLE IF EXISTS {tableOldName} RENAME TO {tableNewName};");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.DBRenameTableError.GetLang(tableOldName, tableNewName), ex);
    }
  }

  /// <summary>
  /// Renames a column if exists.
  /// </summary>
  /// <param name="tableName">Table name.</param>
  /// <param name="columnOldName">Old name.</param>
  /// <param name="columnNewName">New name.</param>
  public void RenameColumnIfExists(string tableName, string columnOldName, string columnNewName)
  {
    if ( tableName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(tableName));
    if ( columnOldName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(columnOldName));
    if ( columnNewName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(columnNewName));
    try
    {
      if ( CheckColumn(tableName, columnOldName) )
        Execute($"ALTER TABLE {tableName} RENAME COLUMN {columnOldName} TO {columnNewName};");
    }
    catch ( Exception ex )
    {
      string message = SysTranslations.DBRenameTableError.GetLang(tableName, columnOldName, columnNewName);
      throw new AdvSQLiteException(message, ex);
    }
  }

  /// <summary>
  /// Checks if a table exists and create it if not.
  /// </summary>
  /// <param name="table">The table name.</param>
  /// <param name="sql">The sql query to create the table, can be empty to only check.</param>
  /// <param name="attached">The attached database</param>
  /// <returns>True if the table exists else false even if created.</returns>
  public bool CheckTable(string table, string sql = null, string attached = null)
  {
    try
    {
      if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));

      string sqlSelect = attached.IsNullOrEmpty()
        ? "SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = ?"
        : $"SELECT count(*) FROM {attached}.sqlite_master WHERE type = 'table' AND name = ?";
      if ( ExecuteScalar<long>(sqlSelect, table) != 0 ) return true;
      if ( !sql.IsNullOrEmpty() )
        try
        {
          CreateCommand(sql).ExecuteNonQuery();
        }
        catch ( Exception ex )
        {
          throw new AdvSQLiteException(SysTranslations.DBCreateTableError.GetLang(table, UnFormatSQL(sql)), ex);
        }
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), table), ex);
    }
    return false;
  }

  /// <summary>
  /// Checks if a index exists and create it if not.
  /// </summary>
  /// <param name="index">The index name.</param>
  /// <param name="sql">The sql query to create the table, can be empty to only check.</param>
  /// <returns>True if the index exists else false even if created.</returns>
  public bool CheckIndex(string index, string sql = null)
  {
    try
    {
      if ( index.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(index));
      const string sqlCheck = "SELECT count(*) FROM sqlite_master WHERE type = 'index' AND name = ?";
      if ( ExecuteScalar<long>(sqlCheck, index) != 0 ) return true;
      if ( !sql.IsNullOrEmpty() )
        try
        {
          Execute(sql);
        }
        catch ( Exception ex )
        {
          throw new AdvSQLiteException(SysTranslations.DBCreateIndexError.GetLang(index, UnFormatSQL(sql)), ex);
        }
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
    return false;
  }

  /// <summary>
  /// Checks if a column of a table exists and create it if not.
  /// </summary>
  /// <remarks>
  /// The existence of the table is not checked.
  /// </remarks>
  /// <param name="table">The table name.</param>
  /// <param name="column">The column name.</param>
  /// <param name="sql">The sql query to create the column, can be empty to only check</param>
  /// <returns>True if the column exists else false even if created.</returns>
  public bool CheckColumn(string table, string column, string sql = null)
  {
    try
    {
      if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));
      if ( column.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(column));
      const string sqlCheck = "SELECT COUNT(*) AS CNTREC FROM pragma_table_info(?) WHERE name = ?";
      if ( ExecuteScalar<long>(sqlCheck, table, column) > 0 ) return true;
      if ( !sql.IsNullOrEmpty() )
        try
        {
          sql = sql.Replace("%TABLE%", table).Replace("%COLUMN%", column);
          Execute(sql);
        }
        catch ( Exception ex )
        {
          throw new AdvSQLiteException(SysTranslations.DBCreateColumnError.GetLang(UnFormatSQL(sql)), ex);
        }
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
    return false;
  }

  /// <summary>
  /// Checks if a column of a table exists and create it if not.
  /// </summary>
  /// <remarks>
  /// The existence of the table is not checked.
  /// </remarks>
  /// <param name="table">The table name.</param>
  /// <param name="column">The column name.</param>
  /// <param name="type">The type of the column.</param>
  /// <param name="valueDefault">The default value.</param>
  /// <param name="valueNotNull">Indicate if not null.</param>
  /// <param name="isPrimary">Indicate if primary key.</param>
  /// <param name="isAutoInc">INdicate if auto inc.</param>
  /// <returns>True if the column exists else false even if created.</returns>
  public bool CheckColumn(string table,
                          string column,
                          string type,
                          string valueDefault,
                          bool valueNotNull,
                          bool isPrimary = false,
                          bool isAutoInc = false)
  {
    if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));
    if ( column.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(column));
    if ( type.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(type));
    if ( !valueDefault.IsNullOrEmpty() ) valueDefault = " DEFAULT " + valueDefault;
    if ( valueNotNull ) valueDefault += " NOT NULL";
    string primary = isPrimary ? "PRIMARY KEY" : string.Empty;
    if ( isAutoInc ) primary += " AUTOINCREMENT ";
    string sql = $"ALTER TABLE %TABLE% ADD COLUMN %COLUMN% {type} {primary} {valueDefault}";
    return CheckColumn(table, column, sql);
  }

  /// <summary>
  /// Gets the number of rows in a table.
  /// </summary>
  /// <param name="table">The table name.</param>
  public long CountRows(string table)
  {
    try
    {
      return ExecuteScalar<long>($"SELECT count(*) FROM {table}");
    }
    catch ( Exception ex )
    {
      throw new AdvSQLiteException(SysTranslations.ErrorInMethod.GetLang(GetClassAndMethodName(), ex.Message), ex);
    }
  }

}
