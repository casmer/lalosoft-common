using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lalosoft.Common;

namespace FileRenamer.DataObjects
{
  public class RenameList : SortableBindingList<RenameInfo>
  {
    public RenameList()
      : base()
    {
    }

    public RenameList(IList<RenameInfo> list)
      : base(list)
    {
    }


  }
}
