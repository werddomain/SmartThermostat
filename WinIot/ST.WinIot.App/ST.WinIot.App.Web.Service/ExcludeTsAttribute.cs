using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Web.Service
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class ExcludeTsAttribute : Attribute
    {    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TsIncludeAttribute : Attribute
    { }
}
