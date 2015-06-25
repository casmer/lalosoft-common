using System;
using System.Collections.Generic;
using System.Text;
using Lalosoft.Common;
using System.ComponentModel;

namespace Lalosoft.Common.Versioning
{
    public class UpgradePathList: SortableBindingList<UpgradePathInfo>
    {
        public UpgradePathList()
            : base()
        {
        }

        public UpgradePathList(IList<UpgradePathInfo> list)
            : base(list)
        {

        }
    }
}
