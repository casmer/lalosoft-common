using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Versioning
{
    public class RegistrationList : SortableBindingList<RegistrationInfo>
    {
        public RegistrationList()
            : base()
        {
        }

        public RegistrationList(IList<RegistrationInfo> list)
            : base(list)
        {

        }
    }
}
