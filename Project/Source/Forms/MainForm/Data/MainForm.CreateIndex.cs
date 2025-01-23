﻿/// <license>
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

  private async Task DoCreateIndexAsync()
  {
    Processing = ProcessingType.CreateIndex;
    Operation = OperationType.Indexing;
    Globals.ChronoBatch.Restart();
    DB.CreateIndex(DecupletRow.TableName, nameof(DecupletRow.Motif), false);
    Globals.ChronoBatch.Stop();
    if ( !CheckIfBatchCanContinueAsync().Result ) return;
    Operation = OperationType.Indexed;
    IsMotifIndexed = DB?.CheckIndex("Decuplets_Motif") ?? false;
  }

}
