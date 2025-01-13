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
  static private string PreviousCount = $"Previous: {{1}}{Globals.NL2}";
  static private string CurrentCount = $"Current: {{2}}{Globals.NL2}";
  static private string LessAtIteration = $"There are less {RepeatedAtIteration}{Globals.NL2}";
  static private string MoreAtIteration = $"There are more {RepeatedAtIteration}{Globals.NL2}";
  static private string StartNextIteration = "Start next iteration?";
  static private string AskStartNextIfLess = $"{LessAtIteration}{PreviousCount}{CurrentCount}{StartNextIteration}";
  static private string AskStartNextIfMore = $"{MoreAtIteration}{PreviousCount}{CurrentCount}{StartNextIteration}";

  private async Task ProcessIterationsAsync(long startingIterationNumber)
  {
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
      if ( CancelRequired )
      {
        UpdateStatusInfo("Canceled");
        break;
      }
      countCurrent = GetRepeatedCount();
      AddIteration(countCurrent);
      string message = $"Iteration #{iteration:000} - Number of repeated motifs : {countCurrent}";
      UpdateStatusInfo(message);
      if ( countCurrent == 0 )
      {
        DisplayManager.Show("There is no repeated motif at iteration #" + iteration);
        break;
      }
      if ( firstIteration )
        if ( countPrevious > countCurrent )
        {
          if ( !DisplayManager.QueryYesNo(string.Format(AskStartNextIfMore, iteration, countPrevious, countCurrent)) )
            break;
        }
        else
        {
          if ( !DisplayManager.QueryYesNo(string.Format(AskStartNextIfLess, iteration, countPrevious, countCurrent)) )
            break;
        }
      countPrevious = countCurrent;
      firstIteration = false;
      UpdateMotifs();
      iteration++;
    }
  }

  private void AddIteration(long repeatedCount)
  {
    DB.Insert(new IterationRow(repeatedCount, DateTime.Now));
  }

  private int GetRepeatedCount()
  {
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

  private void UpdateMotifs()
  {
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
