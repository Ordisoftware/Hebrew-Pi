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
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private ViewConnectors<ViewMode, ToolStripButton> ViewConnectors;

  private void InitializeViewConnectors()
  {
    ViewConnectors = new ViewConnectors<ViewMode, ToolStripButton>
    {
      {
        ViewMode.Decode,
        new ViewConnector<ToolStripButton>
        {
          Component = ActionViewDecode,
          Panel = PanelViewDecode,
          Focused = PanelViewDecode
        }
      },
      {
        ViewMode.Grid,
        new ViewConnector<ToolStripButton>
        {
          Component = ActionViewGrid,
          Panel = PanelViewGrid,
          Focused = PanelViewGrid
        }
      },
      {
        ViewMode.Populate,
        new ViewConnector<ToolStripButton>
        {
          Component = ActionViewPopulate,
          Panel = PanelViewPopulate,
          Focused = PanelViewPopulate
        }
      },
      {
        ViewMode.Normalize,
        new ViewConnector<ToolStripButton>
        {
          Component = ActionViewNormalize,
          Panel = PanelViewNormalize,
          Focused = PanelViewNormalize
        }
      },
      {
        ViewMode.Statistics,
        new ViewConnector<ToolStripButton>
        {
          Component = ActionViewStatistics,
          Panel = PanelViewStatistics,
          Focused = PanelViewStatistics
        }
      },
    };
  }

}
