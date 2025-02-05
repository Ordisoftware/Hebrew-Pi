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

  private readonly Properties.Settings Settings = Program.Settings;

  private const int PiDecimalMotifSize = 10;

  private ReduceRepeatingBase[] SqlHelperList =
  [
    new ReduceRepeatingSqlUpdate(),
    new ReduceRepeatingSqlLoop(),
    //new ReduceRepeatinBigList()
  ];

  private ReduceRepeatingBase SqlHelper;

  internal string NameWorkingDB = "WorkingDB";

  internal SQLiteNetORM DB;

  private volatile string DatabaseFilePath;

  private long PiDecimalsFileSize
  {
    get => Interlocked.Read(ref _PiDecimalsFileSize);
    set => Interlocked.Exchange(ref _PiDecimalsFileSize, value);
  }
  private long _PiDecimalsFileSize;

  private long MotifsProcessedCount
  {
    get => Interlocked.Read(ref _MotifsProcessedCount);
    set => Interlocked.Exchange(ref _MotifsProcessedCount, value);
  }
  private long _MotifsProcessedCount;

  private long ReduceRepeatingIteration
  {
    get => Interlocked.Read(ref _ReduceRepeatingIteration);
    set => Interlocked.Exchange(ref _ReduceRepeatingIteration, value);
  }
  private long _ReduceRepeatingIteration;

  internal long AllRowsCount
  {
    get => Interlocked.Read(ref _countAllRows);
    set => Interlocked.Exchange(ref _countAllRows, value);
  }
  private long _countAllRows;

  internal long LoadedCount
  {
    get => Interlocked.Read(ref _LoadedCount);
    set => Interlocked.Exchange(ref _LoadedCount, value);
  }
  private long _LoadedCount;

  internal long AllRepeatingCount
  {
    get => Interlocked.Read(ref _AllRepeatingCount);
    set => Interlocked.Exchange(ref _AllRepeatingCount, value);
  }
  private long _AllRepeatingCount;

  internal long RepeatingAddedCount
  {
    get => Interlocked.Read(ref _RepeatingAddedCount);
    set => Interlocked.Exchange(ref _RepeatingAddedCount, value);
  }
  private long _RepeatingAddedCount;

  private long DecupletsRowCount
  {
    get => Interlocked.Read(ref _DecupletsRowCount);
    set => Interlocked.Exchange(ref _DecupletsRowCount, value);
  }
  private long _DecupletsRowCount;

  internal bool CanForceTerminateBatch
  {
    get => Interlocked.CompareExchange(ref _CanForceTerminateBatch, 0, 0) == 1;
    set => Interlocked.Exchange(ref _CanForceTerminateBatch, value ? 1 : 0);
  }
  private int _CanForceTerminateBatch;

  private volatile ProcessingType Processing;

  internal volatile OperationType Operation;

  private volatile Exception Except;

  private volatile bool IsMotifColumnIndexed;

  private volatile bool BatchMutex;

}
