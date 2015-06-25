using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Attributes
{
    public class SqlColumnNameAttribute : Attribute
    {
        string _columnName;

        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public SqlColumnNameAttribute(string columnName)
        {
            _columnName = columnName;
        }

        public SqlColumnNameAttribute()
        {
        }
    }
}
