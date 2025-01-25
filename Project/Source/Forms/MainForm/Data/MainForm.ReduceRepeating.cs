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
        {
          lastRow.MaxOccurences = null;
          lastRow.AllRepeatingCount = null;
          lastRow.UniqueRepeatingCount = null;
          lastRow.RemainingRate = null;
          lastRow.RepeatingRate = null;
          lastRow.ElapsedCounting = null;
          iteratingStep = IteratingStep.Counting;
          DB.Update(lastRow);
          LoadIterationGrid();
        }
        else
        if ( lastRow.UniqueRepeatingCount == 0 && lastRow.RemainingRate == 0 )
          return;
        else
        {
          countPrevious = (long)lastRow.UniqueRepeatingCount;
          ReduceRepeatingIteration++;
        }
      }
      Processing = ProcessingType.ReduceRepeating;
      Globals.ChronoBatch.Restart();
      Operation = OperationType.CountingAllRows;
      Globals.ChronoSubBatch.Restart();
      double countRows = DB.Table<DecupletRow>().Count();
      Globals.ChronoSubBatch.Stop();
      Operation = OperationType.CountedAllRows;
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
            countPrevious = (long)lastRow.UniqueRepeatingCount;
          }
          if ( iteratingStep == IteratingStep.Additionning )
            MotifsProcessedCount = (long)row.UniqueRepeatingCount;
        }
        LoadIterationGrid();
        // Count repeating motifs
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        if ( iteratingStep == IteratingStep.Next || iteratingStep == IteratingStep.Counting )
        {
          Globals.ChronoSubBatch.Restart();
          // Grouping
          Operation = OperationType.Grouping;
          DB.CreateUniqueRepeatingMotifsTempTableAsync();
          if ( !CheckIfBatchCanContinueAsync().Result ) break;
          Operation = OperationType.Grouped;
          // Counting unique repeating
          Operation = OperationType.CountingUniqueRepeating;
          var list = DB.GetUniqueRepeatingStatsAsync().Result;
          if ( !CheckIfBatchCanContinueAsync().Result ) break;
          Operation = OperationType.CountedUniqueRepeating;
          //// Counting all repeating
          //Operation = OperationType.CountingAllRepeating;
          //long countAllRepeating = DB.CountAllRepeatingMotifs().Result;
          //Operation = OperationType.CountedAllRepeating;
          Globals.ChronoSubBatch.Stop();
          // Update row
          if ( list.Count == 0 ) throw new AdvSQLiteException("Counting motifs stats error");
          MotifsProcessedCount = list[0].CountMotifs;
          row.UniqueRepeatingCount = MotifsProcessedCount;
          //row.AllRepeatingCount = countAllRepeating;
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
            row.AllRepeatingCount = DB.AddPositionToRepeatingMotifsAsync().Result;
            Globals.ChronoSubBatch.Stop();
            if ( !CheckIfBatchCanContinueAsync().Result ) break;
            Operation = OperationType.Additionned;
            row.ElapsedAdditionning = Globals.ChronoSubBatch.Elapsed;
            row.RepeatingRate = row.AllRepeatingCount is null || row.AllRepeatingCount == 0
              ? 0
              : row.AllRepeatingCount == MotifsProcessedCount
                ? 100
                : Math.Round((double)row.AllRepeatingCount * 100 / countRows, 2);
            DB.Update(row);
            LoadIterationGrid();
          }
          else
          {
            row.AllRepeatingCount = 0;
            row.RepeatingRate = 0;
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
      ex.Manage();
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
