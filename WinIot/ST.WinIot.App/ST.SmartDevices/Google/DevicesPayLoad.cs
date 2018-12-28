using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.GoogleSmartHomeModel
{
    public class DevicesSYNCPayLoad : PayLoadBase
    {
        /// <summary>
        /// String. Optional. For systematic errors on SYNC.
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// String. Optional. Detailed error which will never be presented to users but may be logged or used during development.
        /// </summary>
        public string debugString { get; set; }

        /// <summary>
        /// Array of devices. Zero or more devices are returned (zero devices meaning the user has no devices, or has disconnected them all).
        /// </summary>
        public DeviceSYNC[] devices { get; set; }
    }
}
