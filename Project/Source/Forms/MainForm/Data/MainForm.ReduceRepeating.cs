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

  enum ReduceIteratingStep { Next, Counting, Adding }

  private async Task DoActionReduceRepeatingAsync()
  {
    ReduceIteratingStep iteratingStep = ReduceIteratingStep.Next;
    var table = DB.Table<IterationRow>().ToList();
    IterationRow lastRow = table.LastOrDefault();
    IterationRow row;
    ReduceRepeatingIteration = 0;
    AllRepeatingCount = 1;
    long countPrevious = 0;
    bool hasError = false;
    try
    {
      // Prepare
      if ( lastRow is not null )
        if ( lastRow.ElapsedAdding is not null )
        {
          ReduceRepeatingIteration = lastRow.Iteration + 1;
          iteratingStep = ReduceIteratingStep.Next;
        }
        else
        {
          ReduceRepeatingIteration = lastRow.Iteration;
          iteratingStep = ReduceIteratingStep.Counting;
          //if ( lastRow.ElapsedCounting is null )
          //  iteratingStep = ReduceIteratingStep.Counting;
          //else
          //if ( lastRow.ElapsedAdding is null )
          //{
          //  lastRow.MaxOccurences = null;
          //  lastRow.AllRepeatingCount = null;
          //  lastRow.UniqueRepeatingCount = null;
          //  lastRow.RemainingRate = null;
          //  lastRow.RepeatingRate = null;
          //  lastRow.ElapsedCounting = null;
          //  iteratingStep = ReduceIteratingStep.Counting;
          //  DB.Update(lastRow);
          //  LoadIterationGrid();
          //}
          //else
          if ( lastRow.UniqueRepeatingCount == 0 && lastRow.RemainingRate == 0 )
            return;
          else
          if ( lastRow.UniqueRepeatingCount.HasValue )
            countPrevious = (long)lastRow.UniqueRepeatingCount;
        }
      EditLog.Invoke(EditLog.Clear);
      Processing = ProcessingType.ReduceRepeating;
      // Count all rows
      Globals.ChronoBatch.Restart();
      if ( SelectCountAllRows.Checked )
      {
        Operation = OperationType.CountingAllRows;
        Globals.ChronoSubBatch.Restart();
        AllRowsCount = SqlHelper.GetRowsCount();
        Globals.ChronoSubBatch.Stop();
        WriteLogTime(false);
        WriteLogLine();
        Operation = OperationType.CountedAllRows;
      }
      else
        AllRowsCount = (long)EditMaxMotifs.Value;
      // Loop
      for ( ; AllRepeatingCount > 0; ReduceRepeatingIteration++ )
      {
        EditLog.Invoke(() => EditLog.AppendText("ITERATION #" + ReduceRepeatingIteration + Globals.NL));
        // Init current row
        if ( !CheckIfBatchCanContinueAsync().Result ) break;
        if ( iteratingStep == ReduceIteratingStep.Next )
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
            countPrevious = (long)lastRow.AllRepeatingCount;
          }
          if ( iteratingStep == ReduceIteratingStep.Adding )
            AllRepeatingCount = (long)row.AllRepeatingCount;
        }
        LoadIterationGrid();
        // Count repeating motifs
        if ( iteratingStep == ReduceIteratingStep.Next || iteratingStep == ReduceIteratingStep.Counting )
        {
          Globals.ChronoSubBatch.Restart();
          // Grouping unique repeating
          if ( !CheckIfBatchCanContinueAsync().Result ) return;
          Operation = OperationType.Grouping;
          bool countUniqueToDo = SqlHelper.CreateUniqueRepeatingMotifsTempTable();
          if ( !CheckIfBatchCanContinueAsync().Result ) return;
          WriteLogTime(true);
          Operation = OperationType.Grouped;
          // Counting unique repeating
          if ( countUniqueToDo || row.UniqueRepeatingCount is null )
          {
            Operation = OperationType.CountingUniqueRepeating;
            var list = SqlHelper.GetUniqueRepeatingStats();
            if ( !CheckIfBatchCanContinueAsync().Result ) return;
            WriteLogTime(true);
            Operation = OperationType.CountedUniqueRepeating;
            row.MaxOccurences = list[0].MaxOccurrences;
            row.UniqueRepeatingCount = list[0].CountMotifs;
            row.ElapsedCounting = Globals.ChronoSubBatch.Elapsed;
            DB.Update(row);
            LoadIterationGrid();
          }
          else
          if ( row.ElapsedCounting.HasValue )
          {
            Globals.ChronoSubBatch.AddElapsed(row.ElapsedCounting.Value);
            Globals.ChronoBatch.AddElapsed(row.ElapsedCounting.Value);
          }
          // Degrouping all repeating
          if ( !CheckIfBatchCanContinueAsync().Result ) return;
          Operation = OperationType.Degrouping;
          bool countAllToDo = SqlHelper.CreateAllRepeatingMotifsTempTable();
          WriteLogTime(true);
          Operation = OperationType.Degrouped;
          // Counting all repeating
          if ( countAllToDo || row.AllRepeatingCount is null )
          {
            Operation = OperationType.CountingAllRepeating;
            AllRepeatingCount = SqlHelper.CountAllRepeatingMotifs();
            if ( !CheckIfBatchCanContinueAsync().Result ) return;
            WriteLogTime(true);
            Operation = OperationType.CountedAllRepeating;
            row.AllRepeatingCount = AllRepeatingCount;
            row.ElapsedCounting = Globals.ChronoSubBatch.Elapsed;
            DB.Update(row);
            LoadIterationGrid();
          }
          else
          if ( row.ElapsedCounting.HasValue )
          {
            Globals.ChronoSubBatch.AddElapsed(row.ElapsedCounting.Value);
            Globals.ChronoBatch.AddElapsed(row.ElapsedCounting.Value);
          }
          // Calculate rates and update row
          row.RepeatingRate = row.AllRepeatingCount == 0
            ? 0
            : row.AllRepeatingCount == row.UniqueRepeatingCount
              ? 100
              : Math.Round((double)row.AllRepeatingCount * 100 / AllRowsCount, 2);
          row.RemainingRate = row.AllRepeatingCount == 0
              ? 0
              : ReduceRepeatingIteration == 0
                ? 100
                : Math.Round((double)row.AllRepeatingCount * 100 / countPrevious, 2);
          row.ElapsedCounting = Globals.ChronoSubBatch.Elapsed;
          DB.Update(row);
          LoadIterationGrid();
          Globals.ChronoSubBatch.Stop();
          if ( ReduceRepeatingIteration > 0 && AllRepeatingCount > countPrevious
            && !DisplayManager.QueryYesNo(string.Format(AppTranslations.AskStartNextIfMore,
                                                        ReduceRepeatingIteration,
                                                        countPrevious,
                                                        AllRepeatingCount)) )
          {
            Globals.CancelRequired = true;
            break;
          }
          if ( iteratingStep != ReduceIteratingStep.Next )
            iteratingStep = ReduceIteratingStep.Next;
        }
        countPrevious = AllRepeatingCount;
        // Add position to repeating motifs
        if ( !CheckIfBatchCanContinueAsync().Result ) return;
        if ( iteratingStep == ReduceIteratingStep.Next || iteratingStep == ReduceIteratingStep.Adding )
        {
          if ( AllRepeatingCount > 0 )
          {
            Operation = OperationType.Adding;
            Globals.ChronoSubBatch.Restart();
            long count = SqlHelper.AddPositionToRepeatingMotifs();
            Globals.ChronoSubBatch.Stop();
            if ( !CheckIfBatchCanContinueAsync().Result ) return;
            WriteLogTime(false);
            if ( row.AllRepeatingCount != count )
            {
              WriteLogLine("    Counted: " + row.AllRepeatingCount);
              WriteLogLine("    Added: " + count);
            }
            WriteLogLine();
            Operation = OperationType.Added;
            row.ElapsedAdding = Globals.ChronoSubBatch.Elapsed;
            DB.Update(row);
            LoadIterationGrid();
          }
          else
          {
            row.AllRepeatingCount = 0;
            row.RepeatingRate = 0;
            row.ElapsedAdding = TimeSpan.Zero;
            DB.Update(row);
            LoadIterationGrid();
          }
          if ( iteratingStep != ReduceIteratingStep.Next )
            iteratingStep = ReduceIteratingStep.Next;
        }
        DB.DropTableIfExists($"{NameWorkingDB}.UniqueRepeatingMotifs");
        DB.DropTableIfExists($"{NameWorkingDB}.AllRepeatingMotifs");
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
      Globals.ChronoSubBatch.Stop();
      if ( !hasError )
        if ( Globals.CancelRequired )
          Processing = ProcessingType.Canceled;
        else
          Processing = ProcessingType.Finished;
    }
  }

}
