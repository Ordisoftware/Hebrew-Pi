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

using Equin.ApplicationFramework;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private async Task DoActionNormalize()
  {
    bool hasError = false;
    try
    {
      var lastRow = DB.Table<IterationRow>().ToList().LastOrDefault();
      long indexIteration = lastRow?.Iteration + 1 ?? 0;
      long countPrevious = lastRow?.RepeatedCount ?? 0;
      long countCurrent = 1;
      if ( lastRow is not null && countPrevious == 0 ) return;
      Globals.ChronoBatch.Restart();
      UpdateStatusRemaining(AppTranslations.RemainingNAText);
      for ( ; countCurrent > 0; indexIteration++ )
      {
        if ( !CheckIfBatchCanContinue().Result ) break;
        // Count repeating motifs
        UpdateStatusInfo(string.Format(AppTranslations.IterationText, indexIteration, "?"));
        UpdateStatusAction(AppTranslations.CountingText);
        Globals.ChronoSubBatch.Restart();
        var list = GetRepeatingMotifsAndMaxOccurences().Result;
        countCurrent = list.Count;
        Globals.ChronoSubBatch.Stop();
        var row = new IterationRow
        {
          Iteration = indexIteration,
          RepeatedCount = countCurrent,
          MaxOccurences = list.Any() ? list[0].Occurences : 0,
          RemainingRate = !list.Any()
            ? 0
            : indexIteration == 0
              ? 100
              : Math.Round((double)countCurrent * 100 / countPrevious, 2),
          ElapsedCount = Globals.ChronoSubBatch.Elapsed
        };
        DB.Insert(row);
        LoadIterationGrid();
        UpdateStatusInfo(string.Format(AppTranslations.IterationText, indexIteration, countCurrent));
        UpdateStatusAction(AppTranslations.CountedText);
        if ( indexIteration > 0 && countCurrent > countPrevious
          && !DisplayManager.QueryYesNo(string.Format(AppTranslations.AskStartNextIfMore,
                                                      indexIteration,
                                                      countPrevious,
                                                      countCurrent)) )
        {
          Globals.CancelRequired = true;
          break;
        }
        countPrevious = countCurrent;
        // Add position to repeating motifs
        if ( countCurrent > 0 )
        {
          UpdateStatusAction(AppTranslations.AddingText);
          Globals.ChronoSubBatch.Restart();
          AddPositionToRepeatingMotifs();
          UpdateStatusAction(AppTranslations.AddedText);
          Globals.ChronoSubBatch.Stop();
          row.ElapsedAddition = Globals.ChronoSubBatch.Elapsed;
          DB.Update(row);
          LoadIterationGrid();
        }
      }
    }
    catch ( Exception ex )
    {
      hasError = true;
      UpdateStatusAction(ex.Message);
    }
    finally
    {
      if ( !hasError )
        if ( Globals.CancelRequired )
          UpdateStatusAction(AppTranslations.CanceledText);
        else
          UpdateStatusAction(AppTranslations.FinishedText);
    }
  }

}
