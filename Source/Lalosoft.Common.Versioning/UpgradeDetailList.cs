using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Versioning
{
    public class UpgradeDetailList : SortableBindingList<UpgradeDetailInfo>
    {
        public UpgradeDetailList()
            : base()
        {
        }

        public UpgradeDetailList(IList<UpgradeDetailInfo> list)
            : base(list)
        {

        }
    }
}
