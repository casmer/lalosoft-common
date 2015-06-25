#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Reflection;
//using System.Windows.Forms;

#endregion

namespace Lalosoft.Common
{

  public class SortableBindingList<T> : BindingList<T>, ICloneable, Lalosoft.Common.ISortableBindingList<T>
  {

    private ListSortDirection _sortDirection;
    private PropertyDescriptor _sortProperty;


    #region Removed Items List
    protected List<T> _removedItems = new List<T>();
    [XmlArray("Removed Items")]
    public List<T> RemovedItems
    {
      get { return _removedItems; }
      set { _removedItems = value; }
    }

    protected override void ClearItems()
    {
      base.ClearItems();
      _removedItems.Clear();
    }

    #endregion Removed Items List

    public SortableBindingList()
      : base()
    {
    }

    public SortableBindingList(IList<T> list)
      : base(list)
    {
    }

    protected override void RemoveItem(int index)
    {
      T removedItem = this[index];
      base.RemoveItem(index);
      _removedItems.Add(removedItem);
    }

    public virtual void AddRange(IList<T> items)
    {
      if (items != null)
      {
        foreach (T curItem in items)
        {
          this.Add(curItem);
        }
      }
    }

    #region Sorting

    private bool _isSorted;

    protected override bool SupportsSortingCore
    {
      get { return true; }
    }

    protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
    {
      _sortProperty = property;
      _sortDirection = direction;

      // Get list to sort
      List<T> items = this.Items as List<T>;

      // Apply and set the sort, if items to sort
      if (items != null)
      {
        PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
        items.Sort(pc);
        _isSorted = true;
      }
      else
      {
        _isSorted = false;
      }
      //_sortDirection = _sortDirection == ListSortDirection.Ascending ?
      //                 ListSortDirection.Descending : ListSortDirection.Ascending;
      // Let bound controls know they should refresh their views
      try
      {
        this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
      }
      catch (Exception)
      {
      }
    }
    protected override ListSortDirection SortDirectionCore
    {
      get
      {
        return _sortDirection;
      }
    }

    protected override PropertyDescriptor SortPropertyCore
    {
      get
      {
        return _sortProperty;
      }
    }

    protected override bool IsSortedCore
    {
      get { return _isSorted; }
    }

    protected override void RemoveSortCore()
    {
      _isSorted = false;
    }

    #endregion

    public void Sort(string propertyName)
    {

      List<T> items = base.Items as List<T>;
      PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
      PropertyDescriptor property = props.Find(propertyName, false);
      PropertyComparer<T> pc = new PropertyComparer<T>(property, ListSortDirection.Ascending);
      _sortProperty = property;
      _sortDirection = ListSortDirection.Ascending;
      items.Sort(pc); 
      
    }

    public void Sort(string propertyName, ListSortDirection sortDirection)
    {


      if (propertyName.Contains(","))
      {
        List<string> properties = new List<string>(propertyName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        
        Sort(properties, sortDirection);
        return;
      }

      List<T> items = base.Items as List<T>;
      PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
      PropertyDescriptor property = props.Find(propertyName, false);
      _sortProperty = property;
      _sortDirection = sortDirection;
      PropertyComparer<T> pc = new PropertyComparer<T>(property, sortDirection);
      items.Sort(pc);
    }

    //public void Sort(string propertyName, System.Web.UI.WebControls.SortDirection sortDirection)
    //{
    //    ListSortDirection dir =
    //       (sortDirection == System.Web.UI.WebControls.SortDirection.Ascending) ?
    //           ListSortDirection.Ascending : ListSortDirection.Descending;
    //    if (propertyName.Contains(","))
    //    {
    //        List<string> properties = new List<string>(propertyName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
    //        Sort(properties, dir);
    //        return;
    //    }


    //    List<T> items = base.Items as List<T>;
    //    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
    //    PropertyDescriptor property = props.Find(propertyName, false);
    //    PropertyComparer<T> pc = new PropertyComparer<T>(property, dir);
    //    items.Sort(pc);
    //}

    public void Sort(IComparer<T> propertyComparer)
    {
      List<T> items = base.Items as List<T>;
      items.Sort(propertyComparer);
    }

    public void Sort(List<string> propertyNames, ListSortDirection sortDirection)
    {
      List<T> items = base.Items as List<T>;
      PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
      List<PropertyDescriptor> properties = new List<PropertyDescriptor>();
      foreach (string propertyName in propertyNames)
      {
        PropertyDescriptor property = props.Find(propertyName, false);
        properties.Add(property);
      }
      _sortProperty = properties[0];
      _sortDirection = sortDirection;
      MultiPropertyComparer<T> pc = new MultiPropertyComparer<T>(properties, sortDirection);
      items.Sort(pc);
    }

    public void Sort(List<string> propertyNames, List<ListSortDirection> sortDirections)
    {
      List<T> items = base.Items as List<T>;
      PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
      List<PropertyDescriptor> properties = new List<PropertyDescriptor>();
      foreach (string propertyName in propertyNames)
      {
        PropertyDescriptor property = props.Find(propertyName, false);
        properties.Add(property);
      }
      _sortProperty = properties[0];
      _sortDirection = sortDirections[0];
      MultiPropertyComparer<T> pc = new MultiPropertyComparer<T>(properties, sortDirections);
      items.Sort(pc);
    }


    #region ICloneable Members

    //public object Clone()
    //{
    //    SortableBindingList<T> result = new SortableBindingList<T>();
    //    
    //    return result;
    //}

    public object Clone()
    {
      //First we create an instance of this specific type.
      object newObject = Activator.CreateInstance(this.GetType());
      SortableBindingList<T> result = (SortableBindingList<T>)newObject;
      foreach (T item in this.Items)
      {
        if (item is ICloneable)
        {
          result.Add((T)((ICloneable)item).Clone());
        }
        else
        {
          result.Add(item);
        }
      }
      result._removedItems = new List<T>();
      foreach (T item in _removedItems)
      {

        if (item is ICloneable)
        {
          result._removedItems.Add((T)((ICloneable)item).Clone());
        }
        else
        {
          result._removedItems.Add(item);
        }

      }
      return newObject;
    }


    #endregion
  }
}
