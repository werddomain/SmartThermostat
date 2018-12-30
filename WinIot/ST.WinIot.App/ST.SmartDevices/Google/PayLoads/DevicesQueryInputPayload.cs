using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Google.PayLoads
{
    /// <summary>
    /// Querry Request Payload
    /// </summary>
    public class DevicesQueryInputPayload
    {
        //https://developers.google.com/actions/smarthome/create#actiondevicesquery        /// <summary>
        /// Array<DevicesQueryPayloadDevice>. Required. 
        /// </summary>
        public DevicesQueryInputPayloadDevice[] devices { get; set; }

    }
    public class DevicesQueryInputPayloadDevice {
        /// <summary>
        ///  Required. Partner ID to query, as per the id provided in SYNC
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Optional. If the opaque customData object is provided in SYNC, it's sent here.
        /// </summary>
        public object customData { get; set; }
    }
}
