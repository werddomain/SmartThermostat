using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.GoogleSmartHomeModel
{
    public class DeviceName
    {
        /// <summary>
        /// Optional. List of names provided by the partner rather than the user, often manufacturer names, SKUs, etc.
        /// </summary>
        public string[] defaultNames { get; set; }

        /// <summary>
        /// String. Required. Primary name of the device, generally provided by the user. This is also the name the Assistant will prefer to describe the device in responses.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Array<String>. Optional. Additional names provided by the user for the device.
        /// </summary>
        public string[] nicknames { get; set; }
    }
}
