using System;
using System.Collections.Generic;
using System.Text;

namespace Code_Templater
{
    public class FileListInfo
    {
        string _name;
        string _fullPath;

        public string FullPath
        {
            get { return _fullPath; }
            set { _fullPath = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string TemplateReplace
        {
            get
            {
                return "${" + _name.ToLower() + "}";
            }
        }

        public FileListInfo(string FileName, string FullPath)
        {
            _name = FileName;
            _fullPath = FullPath;
        }
    }
}
