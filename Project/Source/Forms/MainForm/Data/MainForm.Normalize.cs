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

  enum IteratingStep
  {
    Next,
    Counting,
    Additionning
  }

  private async Task DoActionNormalizeAsync()
  {
    bool hasError = false;
    try
    {
      var table = DB.Table<IterationRow>().ToList();
      IteratingStep iteratingStep = IteratingStep.Next;
      long indexIteration = 0;
      long countPrevious = 0;
      long countCurrent = 1;
      IterationRow row;
      IterationRow lastRow = table.LastOrDefault();
      if ( lastRow is not null )
      {
        indexIteration = lastRow.Iteration;
        if ( lastRow.ElapsedCounting is null )
          iteratingStep = IteratingStep.Counting;
        else
        if ( lastRow.ElapsedAdditionning is null )
          iteratingStep = IteratingStep.Additionning;
        else
        {
          countPrevious = (long)lastRow.RepeatedCount;
          indexIteration++;
        }
      }
      Globals.ChronoBatch.Restart();
      UpdateStatusRemaining(AppTranslations.RemainingNAText);
      for ( ; countCurrent > 0; indexIteration++ )
      {
        // Count repeating motifs
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        UpdateStatusInfo(string.Format(AppTranslations.IterationText, indexIteration, "?"));
        UpdateStatusAction(AppTranslations.CountingText);
        Globals.ChronoSubBatch.Restart();
        if ( iteratingStep == IteratingStep.Next )
        {
          row = new IterationRow { Iteration = indexIteration };
          DB.Insert(row);
        }
        else
        {
          row = lastRow;
          if ( indexIteration > 0 )
          {
            lastRow = table[table.Count - 2];
            countPrevious = (long)lastRow.RepeatedCount;
          }
          if ( iteratingStep == IteratingStep.Additionning )
            countCurrent = (long)row.RepeatedCount;
        }
        LoadIterationGrid();
        if ( iteratingStep == IteratingStep.Next || iteratingStep == IteratingStep.Counting )
        {
          var list = DB.GetRepeatingMotifCountAndMaxOccurencesAsync().Result;
          if ( !CheckIfBatchCanContinueAsync().Result ) break;
          countCurrent = list[0].MotifCount;
          Globals.ChronoSubBatch.Stop();
          row.RepeatedCount = countCurrent;
          row.MaxOccurences = list[0].MaxOccurences;
          row.RemainingRate = countCurrent == 0
              ? 0
              : indexIteration == 0
                ? 100
                : Math.Round((double)countCurrent * 100 / countPrevious, 2);
          row.ElapsedCounting = Globals.ChronoSubBatch.Elapsed;
          DB.Update(row);
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
          if ( iteratingStep != IteratingStep.Next )
            iteratingStep = IteratingStep.Next;
        }
        countPrevious = countCurrent;
        // Add position to repeating motifs
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        if ( iteratingStep == IteratingStep.Next || iteratingStep == IteratingStep.Additionning )
        {
          if ( countCurrent > 0 )
          {
            UpdateStatusAction(AppTranslations.AdditionningText);
            Globals.ChronoSubBatch.Restart();
            DB.AddPositionToRepeatingMotifsAsync();
            if ( !CheckIfBatchCanContinueAsync().Result ) break;
            UpdateStatusAction(AppTranslations.AddedText);
            Globals.ChronoSubBatch.Stop();
            row.ElapsedAdditionning = Globals.ChronoSubBatch.Elapsed;
            DB.Update(row);
            LoadIterationGrid();
          }
          else
          {
            row.ElapsedAdditionning = TimeSpan.Zero;
            DB.Update(row);
            LoadIterationGrid();
          }
          if ( iteratingStep != IteratingStep.Next )
            iteratingStep = IteratingStep.Next;
        }
        if ( !EditNormalizeAutoLoop.Checked ) break;
      }
    }
    catch ( Exception ex )
    {
      hasError = true;
      UpdateStatusAction(ex.Message);
      ex.Manage();
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
