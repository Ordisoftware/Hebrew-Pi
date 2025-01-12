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
/// <edited> 2025-01-12 </edited>
namespace Ordisoftware.Hebrew.Pi;

static partial class AppTranslations
{

  static public readonly TranslationsDictionary ApplicationDescription = new()
  {
    [Language.EN] = "",
    [Language.FR] = ""
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
  };

}
