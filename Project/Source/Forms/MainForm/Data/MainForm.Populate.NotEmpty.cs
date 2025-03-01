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

  private void AskWhatToDoOnNonEmptyTable()
  {
    string title = "Table is not empty";
    string msg = $"""
                        Table has {DecupletsRowCount:N0} rows already inserted.

                        Do you want to continue inserting the decuplets, clear everything and start over, or cancel?
                        """;
    using var form = new MessageBoxEx(title, msg,
                                      buttons: MessageBoxButtons.YesNo,
                                      icon: MessageBoxIcon.Question,
                                      width: MessageBoxEx.DefaultWidthMedium,
                                      justify: false,
                                      showInTaskBar: true);
    if ( !Globals.MainForm.Visible || Globals.MainForm.WindowState == FormWindowState.Minimized )
      form.StartPosition = FormStartPosition.CenterScreen;
    form.ActionCancel.Visible = true;
    form.ActionYes.Text = "Continue";
    form.ActionNo.Text = "Empty";
    form.ActionCancel.Text = "Cancel";
    form.ActiveControl = form.ActionYes;
    switch ( form.ShowDialog() )
    {
      case DialogResult.Yes:
        break;
      case DialogResult.No:
        Operation = OperationType.Emptying;
        Globals.ChronoSubBatch.Restart();
        DB.DropTable<DecupletRow>();
        DB.DropTable<IterationRow>();
        DB.CreateTable<DecupletRow>();
        DB.CreateTable<IterationRow>();
        Globals.ChronoSubBatch.Stop();
        DecupletsRowCount = 0;
        Operation = OperationType.Emptied;
        break;
      case DialogResult.Cancel:
        Globals.CancelRequired = true;
        return;
    }
  }

}
