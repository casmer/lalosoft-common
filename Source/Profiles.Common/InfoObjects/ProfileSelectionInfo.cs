using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lalosoft.Profiles.Common.InfoObjects
{
  public class ProfileSelectionInfo
  {
    ProfileInfo _profile;

    public Lalosoft.Profiles.Common.InfoObjects.ProfileInfo Profile
    {
      get { return this._profile; }
      set { this._profile = value; }
    }
  }
}
