using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.SmartDevices.Google.PayLoads
{
    /// <summary>
    /// Devices SYNC Response Payload
    /// </summary>
    public class DevicesSyncPayLoad : PayLoadBase
    {
        //https://developers.google.com/actions/smarthome/create#actiondevicessync
        /// <summary>
        /// String (up to 256 bytes). Required. Reﬂects the unique (and immutable) user ID on the agent's platform. The string is opaque to Google, so if there's an immutable form vs a mutable form on the agent side, use the immutable form (e.g. an account number rather than email).
        /// </summary>
        public string agentUserId { get; set; }

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
