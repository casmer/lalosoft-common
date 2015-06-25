using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Lalosoft.Common.Lib
{
  public class PropertyFieldPair
  {
    PropertyInfo _property;
    string _field;

    public System.Reflection.PropertyInfo Property
    {
      get { return this._property; }
      set { this._property = value; }
    }

    public string Field
    {
      get { return this._field; }
      set { this._field = value; }
    }

    public PropertyFieldPair(PropertyInfo property, string field)
    {
      _property = property;
      _field = field;
    }
  }
}
