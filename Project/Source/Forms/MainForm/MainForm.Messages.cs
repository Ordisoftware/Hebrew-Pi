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
/// <created> 2025-01-10 </created>
/// <edited> 2025-01-13 </edited>
namespace Ordisoftware.Hebrew.Pi;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm : Form
{

  // Text file
  static private string File_NoRepeatedText = "Aucun répété.";
  static private string File_PrefixText = "Sur l'échantillon donné, la théorie des répétés ajoutés aux positions";
  static private string File_OkText = $"{File_PrefixText} fonctionne.";
  static private string File_NotOkText = $"{File_PrefixText} ne fonctionne pas.";
  static private string File_SavedFixedText = "Les groupes dupliquée ont été corrigés et le fichier reconstruit.";

  // Database
  static private string RepeatedAtIteration = $"repeating motifs at iteration #{{0}}{Globals.NL2}";
  static private string PreviousAndCurrentCount = $"Previous: {{1}}{Globals.NL}Current: {{2}}{Globals.NL2}";
  static private string LessAtIteration = $"There are less {RepeatedAtIteration}{Globals.NL2}";
  static private string MoreAtIteration = $"There are more {RepeatedAtIteration}{Globals.NL2}";
  static private string StartNextIteration = "Start the next iteration?";
  static private string AskStartNextIfLess = $"{LessAtIteration}{PreviousAndCurrentCount}{StartNextIteration}";
  static private string AskStartNextIfMore = $"{MoreAtIteration}{PreviousAndCurrentCount}{StartNextIteration}";

  static private string NoRepeatedText = "There is no repeating motif at iteration {0}";
  static private string IterationText = "Iteration {0} : {1} repeating";
  static private string CountingText = "Counting...";
  static private string CountedText = "Counted";
  static private string UpdatingText = "Adding position...";
  static private string CommittingText = "Committing...";
  static private string IndexingText = "Indexing...";
  static private string FinishedText = "Finished";
  static private string CanceledText = "Canceled";

  static private string DroppingTablesText = "Dropping tables...";
  static private string CreatingTablesText = "Creating tables...";
  static private string PopulatingText = "Populating...";
  static private string PopulatingAndRemainingText = "Populating... ({0} remaining before indexing)";

}
