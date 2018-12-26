using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Web.Service.Entity.CSServiceObjects
{
    public static class Extensions
    {
        public static object NullToDbNull(this object value)
        {
            return ST.WinIot.App.Web.Service.Utility.NullToDBNull(value);

        }
    }
}
