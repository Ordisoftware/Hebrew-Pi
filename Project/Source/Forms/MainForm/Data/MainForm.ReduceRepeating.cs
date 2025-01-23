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

  private async Task DoActionReduceRepeatingAsync()
  {
    IteratingStep iteratingStep = IteratingStep.Next;
    var table = DB.Table<IterationRow>().ToList();
    IterationRow lastRow = table.LastOrDefault();
    IterationRow row;
    ReduceRepeatingIteration = 0;
    MotifsProcessedCount = 1;
    long countPrevious = 0;
    bool hasError = false;
    try
    {
      // Prepare
      if ( lastRow is not null )
      {
        ReduceRepeatingIteration = lastRow.Iteration;
        if ( lastRow.ElapsedCounting is null )
          iteratingStep = IteratingStep.Counting;
        else
        if ( lastRow.ElapsedAdditionning is null )
          iteratingStep = IteratingStep.Additionning;
        else
        if ( lastRow.RepeatedCount == 0 && lastRow.RemainingRate == 0 )
          return;
        else
        {
          countPrevious = (long)lastRow.RepeatedCount;
          ReduceRepeatingIteration++;
        }
      }
      Processing = ProcessingType.ReduceRepeating;
      Globals.ChronoBatch.Restart();
      // Loop
      for ( ; MotifsProcessedCount > 0; ReduceRepeatingIteration++ )
      {
        // Init current row
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        if ( iteratingStep == IteratingStep.Next )
        {
          row = new IterationRow { Iteration = ReduceRepeatingIteration };
          DB.Insert(row);
        }
        else
        {
          row = lastRow;
          if ( ReduceRepeatingIteration > 0 )
          {
            lastRow = table[table.Count - 2];
            countPrevious = (long)lastRow.RepeatedCount;
          }
          if ( iteratingStep == IteratingStep.Additionning )
            MotifsProcessedCount = (long)row.RepeatedCount;
        }
        LoadIterationGrid();
        // Count repeating motifs
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        if ( iteratingStep == IteratingStep.Next || iteratingStep == IteratingStep.Counting )
        {
          Operation = OperationType.Grouping;
          Globals.ChronoSubBatch.Restart();
          DB.CreateRepeatingMotifsTableAsync();
          Operation = OperationType.Grouped;
          if ( !CheckIfBatchCanContinueAsync().Result ) break;
          Operation = OperationType.Counting;
          var list = DB.GetRepeatingMotifCountAndMaxOccurencesAsync().Result;
          Globals.ChronoSubBatch.Stop();
          Operation = OperationType.Counted;
          if ( !CheckIfBatchCanContinueAsync().Result ) break;
          MotifsProcessedCount = list[0].MotifCount;
          row.RepeatedCount = MotifsProcessedCount;
          row.MaxOccurences = list[0].MaxOccurrences;
          row.RemainingRate = MotifsProcessedCount == 0
              ? 0
              : ReduceRepeatingIteration == 0
                ? 100
                : Math.Round((double)MotifsProcessedCount * 100 / countPrevious, 2);
          row.ElapsedCounting = Globals.ChronoSubBatch.Elapsed;
          DB.Update(row);
          LoadIterationGrid();
          if ( ReduceRepeatingIteration > 0 && MotifsProcessedCount > countPrevious
            && !DisplayManager.QueryYesNo(string.Format(AppTranslations.AskStartNextIfMore,
                                                        ReduceRepeatingIteration,
                                                        countPrevious,
                                                        MotifsProcessedCount)) )
          {
            Globals.CancelRequired = true;
            break;
          }
          if ( iteratingStep != IteratingStep.Next )
            iteratingStep = IteratingStep.Next;
        }
        countPrevious = MotifsProcessedCount;
        // Add position to repeating motifs
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        if ( iteratingStep == IteratingStep.Next || iteratingStep == IteratingStep.Additionning )
        {
          if ( MotifsProcessedCount > 0 )
          {
            Operation = OperationType.Additionning;
            Globals.ChronoSubBatch.Restart();
            DB.AddPositionToRepeatingMotifsAsync();
            Globals.ChronoSubBatch.Stop();
            Operation = OperationType.Additionned;
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
      Processing = ProcessingType.Error;
      hasError = true;
      Except = ex;
    }
    finally
    {
      if ( !hasError )
        if ( Globals.CancelRequired )
          Processing = ProcessingType.Canceled;
        else
          Processing = ProcessingType.Finished;
    }
  }

}
