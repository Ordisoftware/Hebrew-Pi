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
/// Provides application statistics.
/// </summary>
class ApplicationStatistics
{

  static public readonly ApplicationStatistics Instance = new();

  public string StartingTime
    => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();

  public string TranslateTime
    => Program.Settings.BenchmarkTranslate.FormatMilliseconds();

  public string LoadDataTime
    => Program.Settings.BenchmarkLoadData.FormatMilliseconds();

  public string RenderingTime
    => Program.Settings.BenchmarkRendering.FormatMilliseconds();

  public string DBTotalRecordsCount
    => MainForm.Instance.DB?.CountRows(DecupletRow.TableName).ToString() ?? SysTranslations.NullSlot.GetLang();

  public string DBEngine
    => SQLiteNetORM.EngineNameAndVersion;

  public string DBProvider
    => SQLiteNetORM.ProviderName;

  public string DBFileSize
  {
    get
    {
      if ( UpdateDBFileSizeRequired )
      {
        UpdateDBFileSizeRequired = false;
        _DBFileSize = SystemManager.GetFileSize(Globals.ApplicationDatabaseFilePath).FormatBytesSize();
      }
      return _DBFileSize;
    }
  }
  static private string _DBFileSize;
  static internal bool UpdateDBFileSizeRequired { get; set; } = true;

  public string DBMemorySize
  {
    get
    {
      if ( Program.Settings.SystemStatisticsCalculateDbSize && UpdateDBMemorySizeRequired )
        try
        {
          LoadingForm.Instance.Initialize(SysTranslations.CalculatingDataMemorySize.GetLang(), 4, quantify: false);
          UpdateDBMemorySizeRequired = false;
          long size1 = 0; // ApplicationDatabase.Instance.Decuplets?.SizeOf() ?? 0;
          LoadingForm.Instance.DoProgress();
          _DBMemorySize = size1 > 0
            ? size1.FormatBytesSize()
            : size1 == 0
              ? SysTranslations.DatabaseTableClosed.GetLang()
              : "-";
        }
        finally
        {
          LoadingForm.Instance.Hide();
        }
      return _DBMemorySize;
    }
  }
  static private string _DBMemorySize = "-";
  static internal bool UpdateDBMemorySizeRequired { get; set; } = true;

  public string DBCommonFileSize
  {
    get
    {
      if ( UpdateDBCommonFileSizeRequired )
      {
        UpdateDBCommonFileSizeRequired = false;
        _DBCommonFileSize = SystemManager.GetFileSize(Globals.CommonDatabaseFilePath).FormatBytesSize();
      }
      return _DBCommonFileSize;
    }
  }
  static private string _DBCommonFileSize;
  static internal bool UpdateDBCommonFileSizeRequired { get; set; } = true;

}
