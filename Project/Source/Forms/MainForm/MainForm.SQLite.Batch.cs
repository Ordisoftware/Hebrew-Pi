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
/// <created> 2025-01-13 </created>
/// <edited> 2025-01-13 </edited>
namespace Ordisoftware.Hebrew.Pi;

public partial class MainForm
{

  static private string RepeatedAtIteration = $"repeated motifs at iteration #{{0}}{Globals.NL2}";
  static private string PreviousAndCurrentCount = $"Previous: {{1}}{Globals.NL}Current: {{2}}{Globals.NL2}";
  static private string LessAtIteration = $"There are less {RepeatedAtIteration}{Globals.NL2}";
  static private string MoreAtIteration = $"There are more {RepeatedAtIteration}{Globals.NL2}";
  static private string StartNextIteration = "Start next iteration?";
  static private string AskStartNextIfLess = $"{LessAtIteration}{PreviousAndCurrentCount}{StartNextIteration}";
  static private string AskStartNextIfMore = $"{MoreAtIteration}{PreviousAndCurrentCount}{StartNextIteration}";

  static private string NoRepeatedText = $"There is no repeated motif at iteration {{0}}";
  static private string IterationText = $"Iteration {{0}} : {{1}} repeated";
  static private string CountingText = "Counting...";
  static private string UpdatingText = "Updating...";
  static private string ReadyText = "Ready";
  static private string FinishedText = "Finished";
  static private string CanceledText = "Canceled";

  private async Task ProcessIterationsAsync(long startingIterationNumber)
  {
    count = 10;
    if ( startingIterationNumber == 0 )
    {
      DB.DropTable<IterationRow>();
      DB.CreateTable<IterationRow>();
    }
    bool firstIteration = true;
    long countPrevious = 0;
    long countCurrent = 0;
    long iteration = 0;
    while ( true )
    {
      if ( CancelRequired ) break;
      UpdateStatusProgress(string.Format(IterationText, iteration, "?"));
      UpdateStatusInfo(CountingText);
      countCurrent = GetRepeatedCount().Result;
      AddIteration(countCurrent);
      UpdateStatusProgress(string.Format(IterationText, iteration, countCurrent));
      UpdateStatusInfo(ReadyText);
      if ( CancelRequired ) break;
      if ( countCurrent == 0 )
      {
        DisplayManager.Show(string.Format(NoRepeatedText, iteration));
        break;
      }
      if ( !firstIteration )
        if ( countPrevious > countCurrent )
        {
          if ( !DisplayManager.QueryYesNo(string.Format(AskStartNextIfMore, iteration, countPrevious, countCurrent)) )
            CancelRequired = true;
        }
        else
        {
          if ( !DisplayManager.QueryYesNo(string.Format(AskStartNextIfLess, iteration, countPrevious, countCurrent)) )
            CancelRequired = true;
        }
      countPrevious = countCurrent;
      firstIteration = false;
      UpdateStatusInfo(UpdatingText);
      UpdateMotifs();
      if ( CancelRequired ) break;
      iteration++;
    }
    if ( CancelRequired )
      UpdateStatusInfo(CanceledText);
    else
      UpdateStatusInfo(FinishedText);
  }

  private void AddIteration(long repeatedCount)
  {
    DB.Insert(new IterationRow(repeatedCount, DateTime.Now));
  }

  int count = 10;

  private async Task<int> GetRepeatedCount()
  {
    await Task.Delay(1000);
    return count--;
    try
    {
      var query = @"SELECT COUNT(DISTINCT Motif) AS UniqueRepeated
                  FROM Decuplets
                  WHERE Motif IN (
                    SELECT Motif
                    FROM Decuplets
                    GROUP BY Motif
                    HAVING COUNT(Motif) > 1
                  );";

      return DB.Query<int>(query).Single();
    }
    catch ( Exception ex )
    {
      // TODO manage
      throw;
    }
  }

  private async void UpdateMotifs()
  {
    return;
    var query = @"UPDATE Decuplets
                  SET Motif = Motif + Position
                  WHERE Motif IN (
                    SELECT Motif
                    FROM Decuplets
                    GROUP BY Motif
                    HAVING COUNT(*) > 1
                  );";
    DB.Execute(query);
  }

}
