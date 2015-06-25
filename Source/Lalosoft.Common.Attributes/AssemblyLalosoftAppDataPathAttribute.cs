using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace Lalosoft.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public class AssemblyLalosoftAppDataPathAttribute: Attribute
    {
        string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public AssemblyLalosoftAppDataPathAttribute(string path)
        {
            _path = path;
        }

        public AssemblyLalosoftAppDataPathAttribute()
        {
        }
    }
}
