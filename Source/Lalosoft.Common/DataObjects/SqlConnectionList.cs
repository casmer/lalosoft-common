using System;
using System.Collections.Generic;
using System.Text;
using Lalosoft.Common.InfoObjects;

namespace Lalosoft.Common.DataObjects
{
    public class SqlConnectionList : SortableBindingList<SqlConnectionInfo>
    {
        public SqlConnectionList()
            : base()
        {
        }

        public SqlConnectionList(IList<SqlConnectionInfo> list)
            : base(list)
        {
        }
    }
}
