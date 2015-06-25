using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lalosoft.Common;

namespace GuidConstantGenerator
{
  public class GuidConstantList : SortableBindingList<GuidConstantItem>
  {

  }

  public class GuidConstantItem
  {
    public GuidConstantItem()
    {
      GuidValue = Guid.NewGuid().ToString("D").ToUpper();
    }
    private string _name;

    public string Name
    {
      get { return _name; }
      set { _name = value !=null ? value.ToUpper().Replace(" ","_") : null; }
    }

    public string GuidValue { get; set; }

    public string ConstantDef
    {
      get { return string.Format(@"public const string {0} = ""{1}"";", Name, GuidValue); }
    }
  }
}
