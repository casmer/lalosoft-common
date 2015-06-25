using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Versioning
{
    public class DownloadUrlList : SortableBindingList<DownloadUrlInfo>
    {
        public DownloadUrlList()
            : base()
        {
        }

        public DownloadUrlList(IList<DownloadUrlInfo> list)
            : base(list)
        {

        }
    }
}
