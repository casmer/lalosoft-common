using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Lalosoft.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ComVisible(true)]
    public class AssemblyLalosoftSettingFileAttribute: Attribute
    {
        string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public AssemblyLalosoftSettingFileAttribute(string fileName)
        {
            _fileName = fileName;
        }

        public AssemblyLalosoftSettingFileAttribute()
        {
        }
    }
}
