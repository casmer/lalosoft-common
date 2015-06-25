using System;
using System.Collections.Generic;
using System.Text;
using Lalosoft.Common;
using System.ComponentModel;

namespace Lalosoft.Common.Versioning
{
    public class InstalledVersionList: SortableBindingList<InstalledVersionInfo>
    {
        public InstalledVersionList()
            : base()
        {
        }

        public InstalledVersionList(IList<InstalledVersionInfo> list)
            : base(list)
        {

        }
    }
}
