using System;
namespace Lalosoft.Common
{
  public interface ISortableBindingList<T>
  { 
    void AddRange(System.Collections.Generic.IList<T> items);
    object Clone();
    System.Collections.Generic.List<T> RemovedItems { get; set; }
    void Sort(System.Collections.Generic.List<string> propertyNames, System.Collections.Generic.List<System.ComponentModel.ListSortDirection> sortDirections);
    void Sort(string propertyName, System.ComponentModel.ListSortDirection sortDirection);
    void Sort(System.Collections.Generic.List<string> propertyNames, System.ComponentModel.ListSortDirection sortDirection);
    void Sort(string propertyName);
    void Sort(System.Collections.Generic.IComparer<T> propertyComparer);
  }
}
