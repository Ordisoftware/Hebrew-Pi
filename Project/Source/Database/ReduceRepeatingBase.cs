/// <license>
/// file is part of Ordisoftware Hebrew Pi.
/// Copyright 2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2025-01 </created>
/// <edited> 2025-01 </edited>
namespace Ordisoftware.Hebrew.Pi;

using CountMotifsAndMaxOccurencesTuple = (long CountMotifs, long MaxOccurrences);

abstract class ReduceRepeatingBase
{

  protected SQLiteNetORM DB => MainForm.Instance.DB;

  abstract public void CreateUniqueRepeatingMotifsTempTable();

  abstract public List<CountMotifsAndMaxOccurencesTuple> GetUniqueRepeatingStats();

  abstract public void CreateAllRepeatingMotifsTempTable();

  abstract public long CountAllRepeatingMotifs();

  abstract public long AddPositionToRepeatingMotifs();

  protected void CheckDatabaseNotNull()
  {
    if ( DB is null ) throw new ArgumentNullException("DB");
  }

  public virtual long GetRowsCount()
  {
    CheckDatabaseNotNull();
    return DB.ExecuteScalar<long>($"SELECT COUNT(*) FROM [{DecupletRow.TableName}]");
  }

}
