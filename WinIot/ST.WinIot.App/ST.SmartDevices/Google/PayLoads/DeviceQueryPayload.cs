using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Google.PayLoads
{
    /// <summary>
    /// Device Query Payload Response
    /// </summary>
    public class DeviceQueryPayload:PayLoadBase
    {

    }
    public class DeviceQueryPayloadDevice {
        public bool online { get; set; }

    }
}
