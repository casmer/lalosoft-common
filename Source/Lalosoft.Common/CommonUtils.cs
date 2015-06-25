using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lalosoft.Common
{
  public static class CommonUtils
  {
    public static bool IsNullOrWhiteSpace(string value)
    {
      bool res = false;
      if (value == null)
      {
        res = true;
      }
      else
      {
        res = (value.Trim() == "");
      }

      return res;
    }
  }
}
