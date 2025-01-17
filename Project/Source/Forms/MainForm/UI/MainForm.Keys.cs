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

  private ViewMode[] NagigableViews => ViewConnectors.Keys.ToArray();

  /// <summary>
  /// Process the command key.
  /// </summary>
  /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  [SuppressMessage("Design", "GCop135:{0}", Justification = "N/A")]
  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  [SuppressMessage("Correctness", "SS018:Add cases for missing enum member.", Justification = "N/A")]
  [SuppressMessage("Correctness", "SS019:Switch should have default label.", Justification = "N/A")]
  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    static bool scroll(Panel panel, int ypos, bool abs)
    {
      int dy = abs ? Math.Abs(panel.AutoScrollPosition.Y) : 0;
      panel.AutoScrollPosition = new Point(panel.AutoScrollPosition.X, ypos + dy);
      return true;
    }
    if ( Globals.IsReady )
      switch ( keyData )
      {
        // Top menu system
        case Keys.Alt | Keys.S:
          ActionSettings.ShowDropDown();
          return true;
        case Keys.Alt | Keys.I:
          ActionInformation.ShowDropDown();
          return true;
        case Keys.F9:
          ActionPreferences.PerformClick();
          return true;
        case Keys.Alt | Keys.Control | Keys.F4:
          ActionExit.PerformClick();
          return true;
        // Rotate view
        case Keys.Control | Keys.Shift | Keys.Tab:
          if ( Globals.AllowClose )
            SetView(Settings.CurrentView.Previous());
          return true;
        case Keys.Control | Keys.Tab:
          if ( Globals.AllowClose )
            SetView(Settings.CurrentView.Next());
          return true;
        // Change view
        case Keys.F1:
          ActionViewDecode.PerformClick();
          return true;
        case Keys.F2:
          ActionViewGrid.PerformClick();
          return true;
        case Keys.F3:
          ActionViewPopulate.PerformClick();
          return true;
        case Keys.F4:
          ActionViewNormalize.PerformClick();
          return true;
        case Keys.F5:
          ActionViewStatistics.PerformClick();
          return true;
      }
    return base.ProcessCmdKey(ref msg, keyData);
  }

}
