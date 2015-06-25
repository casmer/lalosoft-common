#region Using directives

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

#endregion


namespace Lalosoft.Common
{
    class MultiPropertyComparer<T> : System.Collections.Generic.IComparer<T>
    {

        // The following code contains code implemented by Rockford Lhotka:
        // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnadvnet/html/vbnet01272004.asp

        private List<PropertyDescriptor> _properties;
        private List<ListSortDirection> _directions;

        public MultiPropertyComparer(List<PropertyDescriptor> properties, List<ListSortDirection> directions)
        {
            if (properties.Count == 0)
                throw new Exception("Must have more than one property in the list!");
            if (properties.Count != directions.Count)
                throw new Exception("Must directions must have the same number of values as the property list.");
            _directions = directions;
            _properties = properties;
        
        }

        public MultiPropertyComparer(List<PropertyDescriptor> properties, ListSortDirection direction)
        {
            if (properties.Count == 0)
                throw new Exception("Must have more than one property in the list!");
            _directions = new List<ListSortDirection>();
            for (int i = 0; i < properties.Count; i++)
                _directions.Add(direction);
            _properties = properties;
      
        }

        #region IComparer<T>

        public int Compare(T xWord, T yWord)
        {
            // Get property values
            int res = 0;
            for (int i = 0; i < _properties.Count; i++)
            {
                PropertyDescriptor property = _properties[i];
                ListSortDirection direction = _directions[i];
                object xValue = GetPropertyValue(xWord, property.Name);
                object yValue = GetPropertyValue(yWord, property.Name);


                // Determine sort order
                if (direction == ListSortDirection.Ascending)
                {
                    res = CompareAscending(xValue, yValue);
                }
                else
                {
                    res = CompareDescending(xValue, yValue);
                }
                if (res != 0)
                    break;
            }
            return res;
        }

        public bool Equals(T xWord, T yWord)
        {
            return xWord.Equals(yWord);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion

        // Compare two property values of any type
        private int CompareAscending(object xValue, object yValue)
        {
            int result;

            // If values implement IComparer
            if (xValue == null || yValue == null)
                result = (xValue == yValue ? 0 : (xValue != null ? -1 : 1));
            else
                if (xValue is IComparable)
                {
                    result = ((IComparable)xValue).CompareTo(yValue);
                }
                // If values don't implement IComparer but are equivalent
                else if (xValue.Equals(yValue))
                {
                    result = 0;
                }
                // Values don't implement IComparer and are not equivalent, so compare as string values
                else result = xValue.ToString().CompareTo(yValue.ToString());

            // Return result
            return result;
        }

        private int CompareDescending(object xValue, object yValue)
        {
            // Return result adjusted for ascending or descending sort order ie
            // multiplied by 1 for ascending or -1 for descending
            return CompareAscending(xValue, yValue) * -1;
        }

        private object GetPropertyValue(T value, string property)
        {
            // Get property
            PropertyInfo propertyInfo = value.GetType().GetProperty(property);

            // Return value
            return propertyInfo.GetValue(value, null);
        }
    }
}
