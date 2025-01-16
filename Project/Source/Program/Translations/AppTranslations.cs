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
/// <created> 2025-01-12 </created>
/// <edited> 2025-01-16 </edited>
namespace Ordisoftware.Hebrew.Pi;

static partial class AppTranslations
{

  static public readonly TranslationsDictionary ApplicationDescription = new()
  {
    [Language.EN] = "Pi decimal decoder and translator using Hebrew Gematria",
    [Language.FR] = "Décodeur et traducteur de décimales de Pi grâce à la Gematria hébraïque"
  };

  static public readonly TranslationsDictionary AskToCreateNewDatabase = new()
  {
    [Language.EN] = "Do you want to create a new database which will replace the actual?",
    [Language.FR] = "Voulez-vous créer une nouvelle base de données qui remplacera l'actuelle ?"
  };

  static public readonly TranslationsDictionary AskToReplaceDatabase = new()
  {
    [Language.EN] = "Do you want to replace the actual database with the selected backup?" + Globals.NL2 + "{0}",
    [Language.FR] = "Voulez-vous remplacer la base de données actuelle avec l'archive sélectionnée ?" + Globals.NL2 + "{0}"
  };

  static public readonly TranslationsDictionary AskToBackupDatabaseBeforeReplace = new()
  {
    [Language.EN] = "Do you want to backup database before replace it?",
    [Language.FR] = "Voulez-vous archiver la base de données avant de la remplacer ?"
  };

  static public readonly TranslationsDictionary NoSearchResultFound = new()
  {
    [Language.EN] = "No result found",
    [Language.FR] = "Aucun résultat trouvé"
  };

  static public readonly NullSafeDictionary<ViewMode, TranslationsDictionary> ViewPanelTitle = new()
  {
    [ViewMode.Decode] = new TranslationsDictionary
    {
      [Language.EN] = "DECODE",
      [Language.FR] = "DÉCODAGE"
    },
    [ViewMode.Grid] = new TranslationsDictionary
    {
      [Language.EN] = "GRID",
      [Language.FR] = "GRILLE"
    },
    [ViewMode.Populate] = new TranslationsDictionary
    {
      [Language.EN] = "POPULATE",
      [Language.FR] = "PEUPLER"
    },
    [ViewMode.Normalize] = new TranslationsDictionary
    {
      [Language.EN] = "NORMALIZE",
      [Language.FR] = "NORMALISER"
    },
    [ViewMode.Statistics] = new TranslationsDictionary
    {
      [Language.EN] = "STATISTICS",
      [Language.FR] = "STATISTIQUES"
    },
  };

  static public string CreateDataProgress = "{0} inserted";
  static public string RepeatedAtIteration = $"repeating motifs at iteration #{{0}}{Globals.NL2}";
  static public string PreviousAndCurrentCount = $"Previous: {{1}}{Globals.NL}Current: {{2}}{Globals.NL2}";
  static public string LessAtIteration = $"There are less {RepeatedAtIteration}{Globals.NL2}";
  static public string MoreAtIteration = $"There are more {RepeatedAtIteration}{Globals.NL2}";
  static public string StartNextIteration = "Start the next iteration?";
  static public string AskStartNextIfLess = $"{LessAtIteration}{PreviousAndCurrentCount}{StartNextIteration}";
  static public string AskStartNextIfMore = $"{MoreAtIteration}{PreviousAndCurrentCount}{StartNextIteration}";

  static public string NoRepeatedText = "There is no repeating motif at iteration {0}";
  static public string IterationText = "Iteration {0} : {1} repeating";
  static public string CountingText = "Counting...";
  static public string CountedText = "Counted";
  static public string UpdatingText = "Adding position...";
  static public string CommittingText = "Committing...";
  static public string IndexingText = "Indexing...";
  static public string FinishedText = "Finished";
  static public string CanceledText = "Canceled";

  static public string EmptyingTablesText = "Emptying tables...";
  static public string PopulatingText = "Populating...";
  static public string PopulatingAndRemainingText = "Populating... ({0} remaining before indexing)";

}
