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

  private async Task DoActionNormalize()
  {
    try
    {
      var last = DB.Table<IterationRow>().ToList().LastOrDefault();
      bool first = true;
      long iteration = 0;
      long countPrevious = 0;
      long countCurrent = 0;
      long startingIterationNumber = last?.Iteration ?? 0;
      if ( startingIterationNumber != 0 )
      {
        iteration = startingIterationNumber + 1;
        countPrevious = last.RepeatedCount;
      }
      while ( true )
      {
        if ( !CheckIfBatchCanContinue().Result ) break;
        UpdateStatusProgress(string.Format(AppTranslations.IterationText, iteration, "?"));
        UpdateStatusInfo(AppTranslations.CountingText);
        var list = GetRepeatingMotifsAndMaxOccurences().Result;
        countCurrent = list.Count;
        long max = list.Any() ? list[0].Occurences : 0;
        UpdateStatusProgress(string.Format(AppTranslations.IterationText, iteration, countCurrent));
        UpdateStatusInfo(AppTranslations.CountedText);
        DB.Insert(new IterationRow { Iteration = iteration, RepeatedCount = countCurrent, MaxOccurences = max });
        GridIterations.Invoke(LoadIterationGrid);
        if ( !CheckIfBatchCanContinue().Result ) break;
        if ( countCurrent == 0 )
        {
          DisplayManager.Show(string.Format(AppTranslations.NoRepeatedText, iteration));
          break;
        }
        if ( !first && countPrevious < countCurrent )
          if ( !DisplayManager.QueryYesNo(string.Format(AppTranslations.AskStartNextIfMore,
                                                        iteration,
                                                        countPrevious,
                                                        countCurrent)) )
            Globals.CancelRequired = true;
        countPrevious = countCurrent;
        UpdateStatusInfo(AppTranslations.UpdatingText);
        AddPositionToRepeatingMotifs();
        if ( !CheckIfBatchCanContinue().Result ) break;
        iteration++;
        first = false;
      }
    }
    finally
    {
      if ( Globals.CancelRequired )
        UpdateStatusInfo(AppTranslations.CanceledText);
      else
        UpdateStatusInfo(AppTranslations.FinishedText);
    }
  }

  private async Task<int> GetRepeatingMotifsCount()
  {
    var sql = @"SELECT COUNT(DISTINCT Motif) AS UniqueRepeated
                FROM Decuplets
                WHERE Motif IN (
                  SELECT Motif
                  FROM Decuplets
                  GROUP BY Motif
                  HAVING COUNT(Motif) > 1
                );";
    return DB.QueryScalars<int>(sql).Single();
  }

  private async Task<List<(long Motif, long Occurences)>> GetRepeatingMotifsAndMaxOccurences()
  {
    var sql = @"SELECT Motif, COUNT(*) AS Occurrences
                FROM Decuplets
                GROUP BY Motif
                HAVING COUNT(*) > 1
                ORDER BY Occurrences DESC;";
    return DB.Query<(long Motif, long Occurences)>(sql).ToList();
  }

  private async void AddPositionToRepeatingMotifs()
  {
    var sql = @"UPDATE Decuplets
                SET Motif = Motif + Position
                WHERE Motif IN (
                  SELECT Motif
                  FROM Decuplets
                  GROUP BY Motif
                  HAVING COUNT(*) > 1
                );";
    DB.Execute(sql);
  }

}
