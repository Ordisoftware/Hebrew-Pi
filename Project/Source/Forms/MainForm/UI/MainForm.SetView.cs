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

  /// <summary>
  /// Set the view panel.
  /// </summary>
  /// <param name="view">The view mode.</param>
  public void SetView(ViewMode view)
  {
    SetView(view, false);
  }

  /// <summary>
  /// Set the view panel.
  /// </summary>
  /// <param name="view">The view mode.</param>
  /// <param name="first">true to first.</param>
  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  [SuppressMessage("Design", "GCop135:{0}", Justification = "N/A")]
  public void SetView(ViewMode view, bool first)
  {
    if ( Settings.CurrentView == view && !first ) return;
    ViewConnectors[Settings.CurrentView].Component.Checked = false;
    ViewConnectors[Settings.CurrentView].Panel.Parent = null;
    ViewConnectors[view].Component.Checked = true;
    ViewConnectors[view].Panel.Parent = PanelMainCenter;
    ViewConnectors[view].Focused?.Focus();
    Settings.CurrentView = view;
    LabelTitleLeft.Text = AppTranslations.ViewPanelTitle.GetLang(view).ToUpper();
    UpdateButtons();
  }

}
