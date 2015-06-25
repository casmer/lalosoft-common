using System;
using System.Collections.Generic;
using System.Text;
using Lalosoft.Common;
using System.ComponentModel;

namespace Lalosoft.Common.Versioning
{
    public class VersionList : SortableBindingList<VersionInfo> , IBindingListView
    {
        public VersionList()
            : base()
        {
        }

        public VersionList(IList<VersionInfo> list)
            : base(list)
        {

        }

        

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            
            return base.FindCore(prop, key);
        }

        #region IBindingListView Members

        public void ApplySort(ListSortDescriptionCollection sorts)
        {
            foreach (ListSortDescription curItem in sorts)
            {
                
            }
        }

        public string Filter
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
                
            }

        }

        public void RemoveFilter()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ListSortDescriptionCollection SortDescriptions
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool SupportsAdvancedSorting
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool SupportsFiltering
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        
        #endregion
    }
}
