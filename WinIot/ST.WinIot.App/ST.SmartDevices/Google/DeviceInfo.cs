using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.GoogleSmartHomeModel
{
    public class DeviceInfo
    {
        /// <summary>
        /// String. Especially useful when the partner is a hub for other devices. Google may provide a standard list of manufacturers here so that e.g. TP-Link and Smartthings both describe 'osram' the same way.
        /// </summary>
        public string manufacturer { get; set; }

        /// <summary>
        /// String. The model or SKU identifier of the particular device.
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// String. Specific version number attached to the hardware if available.
        /// </summary>
        public string hwVersion { get; set; }

        /// <summary>
        /// String. Specific version number attached to the software/firmware, if available.
        /// </summary>
        public string swVersion { get; set; }
    }
}
