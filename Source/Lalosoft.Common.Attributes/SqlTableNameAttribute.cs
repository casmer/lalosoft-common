using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Attributes
{
    public class SqlTableNameAttribute: Attribute
    {
        string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public SqlTableNameAttribute(string tableName)
        {
            _tableName = tableName;
        }

        public SqlTableNameAttribute()
        {
        }
    }
}
