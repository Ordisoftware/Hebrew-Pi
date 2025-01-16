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

/// <summary>
/// Provides view mode.
/// </summary>
public enum ViewMode
{

  /// <summary>
  /// Decode and translate view.
  /// </summary>
  Decode,

  /// <summary>
  /// Data view.
  /// </summary>
  Grid,

  /// <summary>
  /// Create data in tables view.
  /// </summary>
  Populate,

  /// <summary>
  /// Reduce repetitions.
  /// </summary>
  Normalize,

  /// <summary>
  /// Iteration reducing statistics view.
  /// </summary>
  Statistics

}
