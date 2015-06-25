using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileRenamer.DataObjects
{
  public class RenameInfo : IComparable

  {
    string _originalFilePath;
    string _newFilePath;

    public string OriginalFilePath
    {
      get { return this._originalFilePath; }
      set { this._originalFilePath = value; }
    }

    public string NewFilePath
    {
      get { return this._newFilePath; }
      set { this._newFilePath = value; }
    }

    public RenameInfo()
    {
    }

    public RenameInfo(string filename)
    {
      _newFilePath = filename;
      _originalFilePath = filename;
    }

    #region IComparable Members

    public int CompareTo(object obj)
    {
      if (obj is RenameInfo)
      {
        RenameInfo objC = (RenameInfo)obj;

        if ((objC == null || objC._originalFilePath == null) && _originalFilePath != null)
          return -1;
        else if (objC._originalFilePath == null && _originalFilePath == null)
          return 0;
        else if (objC._originalFilePath != null && _originalFilePath == null)
          return 1;
        else
          return _originalFilePath.ToLower().CompareTo(((RenameInfo)obj)._originalFilePath.ToLower());
      }
      else
        throw new Exception("Must be rename info");
    }

    public override bool Equals(object obj)
    {
      if (obj is RenameInfo)
      {
        if (obj == null)
          return false;
        else
          return CompareTo(obj) == 0;
      }
      else
        return false;
      
    }

    #endregion
  }
}
