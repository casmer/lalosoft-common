using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lalosoft.VersionIncrementor
{
  public class VersionBase
  {
    int _major = 1;
    int _minor = 0;

    public int Major
    {
      get { return this._major; }
      set { this._major = value; }
    }

    public int Minor
    {
      get { return this._minor; }
      set { this._minor = value; }
    }

    public VersionBase(int major, int minor)
    {
      _major = major;
      _minor = minor;
    }
    public VersionBase()
    {
    }
  }
}
