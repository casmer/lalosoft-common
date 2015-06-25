using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Lalosoft.Common.Exceptions;
using Lalosoft.Common.Attributes;
namespace Lalosoft.Common.DisplayListString
{
    public class DisplayListStringItem: IComparable
    {
        
        #region Constructors
        static bool _valueOnlyCompare=false;

        public static bool ValueOnlyCompare
        {
            get { return _valueOnlyCompare; }
            set { _valueOnlyCompare = value; }
        }

        public DisplayListStringItem()
        {
        }

        public DisplayListStringItem(string value, string display)
        {
            _value = value;
            _display = display;
        }
        #endregion Constructors

        #region Private Variables
        string _value = "";
        string _display = "";
        #endregion Private Variables

        #region Properties
        [XmlElement("Value")]
        public string Value
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


        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is DisplayListStringItem && _value is IComparable)
            {
                DisplayListStringItem cObj = (DisplayListStringItem)obj;

                int res = ((IComparable)_value).CompareTo(cObj._value);
                if (res == 0 && !_valueOnlyCompare)
                    res = _display.CompareTo(cObj._display);
                return res;
            }
            else
            {
                throw new LalosException("Can not Compare string Values (DisplayListItemString CompareTo)");
            }
        }
        public override int GetHashCode()
        {
          return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.CompareTo(obj) == 0;
        }
        #endregion
    }
}
