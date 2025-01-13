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

  private async Task ProcessIterationsAsync(long firstIteration)
  {
    long countIteration = 0;
    while ( true )
    {
      long countRepeated = GetRepeatedCount();
      string message = $"Iteration #{countIteration:000} - Number of duplicated motifs : {countRepeated}";
      UpdateStatusInfo(message);
      SaveIteration(countRepeated);
      if ( countRepeated == 0 )
      {
        DisplayManager.Show("There are no more repeating motifs at iteration #" + countIteration);
        break;
      }
      if ( !DisplayManager.QueryYesNo(message + Globals.NL2 + "Start next iteration?") )
        break;
      UpdateMotifs();
      countIteration++;
    }
  }

  private void SaveIteration(long repeatedCount)
  {
    DB.Insert(new AddPositionIterationRow(repeatedCount, DateTime.Now));
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
