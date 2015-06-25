using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Versioning
{
    public class InstalledVersionInfo
    {
        VersionInfo _info;

        public VersionInfo Info
        {
            get { return _info; }
            set { _info = value; }
        }
        string _pathToAssembly;

        public string PathToAssembly
        {
            get { return _pathToAssembly; }
            set { _pathToAssembly = value; }
        }

        public InstalledVersionInfo()
        {
            _info = null;
            _pathToAssembly = null;
        }

        public InstalledVersionInfo(VersionInfo info, string pathToAssembly)
        {
            _info = info;
            _pathToAssembly = pathToAssembly;
        }

        

    }
}
