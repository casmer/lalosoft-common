using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lalosoft.Common;
using Lalosoft.Profiles.Common.InfoObjects;

namespace Lalosoft.Profiles.Common.DataObjects
{
  public class ProfileList :SortableBindingList<ProfileInfo>
  {
    public ProfileList() : base() { }
    public ProfileList(IList<ProfileInfo> list) : base(list) { }

  }
}
