using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Lalosoft.Common.Exceptions;
using Lalosoft.Common.Attributes;
namespace Lalosoft.Common.DisplayList
{
    public class DisplayListItem: IComparable
    {
        
        #region Constructors
        public DisplayListItem()
        {
        }

        public DisplayListItem(object value, string display)
        {
            _value = value;
            _display = display;
        }
        #endregion Constructors

        #region Private Variables
        object _value = 0;
        string _display = "";
        #endregion Private Variables

        #region Properties
        [XmlElement("Value")]
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        [XmlElement("Display")]
        public string Display
        {
            get { return _display; }
            set { _display = value; }
        }
        #endregion Properties

        public override int GetHashCode()
        {
          return base.GetHashCode();
        }
        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is DisplayListItem && _value is IComparable)
            {
                DisplayListItem cObj = (DisplayListItem)obj;

                int res = ((IComparable)_value).CompareTo(cObj._value);
                //if (res == 0)
                //    res = _display.CompareTo(cObj._display);
                return res;
            }
            else
            {
                throw new LalosException("Can not Compare Object Values (DisplayListItem CompareTo)");
            }
        }
        public override bool Equals(object obj)
        {
          if (obj is DisplayListItem)
            if (obj == null)
              return false;
            else
              return CompareTo(obj) == 0;
          else
            return base.Equals(obj);
        }

        #endregion
    }
}
