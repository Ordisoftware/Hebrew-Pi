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

using Microsoft.WindowsAPICodePack.Taskbar;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private readonly Properties.Settings Settings = Program.Settings;

  private TaskbarManager TaskBar = TaskbarManager.Instance;

  private const long PiDecimalMotifSize = 10;

  private int FileReadBufferSize = 10_000_000;

  private bool CanForceTerminateBatch;

  private volatile bool IsMotifsProcessing;

  private long MotifsProcessedCount;

  private long DecupletsRowCount;

  private long PiDecimalsFileSize;

  private string DatabaseFilePath;

  private string SQLiteTempDir = @"D:\";

  private int SQLiteCacheSize;

  private SQLiteNetORM DB;

}
