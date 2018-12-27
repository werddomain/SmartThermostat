using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.GoogleSmartHomeModel
{
    public class DeviceSYNC
    {
        /// <summary>
        /// String. Required. The ID of the device in the partner's cloud. This must be unique for the user and for the partner, as in cases of sharing we may use this to dedupe multiple views of the same device. It should be immutable for the device; if it changes, the Assistant will treat it as a new device.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// String. Required. The hardware type of device (for example, action.devices.types.LIGHT). 
        /// See the full list of device types : https://developers.google.com/actions/smarthome/guides/
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Array<String>. Required. List of traits this device supports (for example, action.devices.traits.OnOff). This deﬁnes the commands, attributes, and states that the device has. 
        /// See the full list of device traits :https://developers.google.com/actions/smarthome/traits/
        /// </summary>
        public string[] traits { get; set; }

        /// <summary>
        /// Object. Required. Names of this device.
        /// </summary>
        public DeviceName name { get; set; }

        /// <summary>
        /// Boolean. Required. Indicates whether this device will have its states updated by the Real Time Feed. (TRUE to use the Real Time Feed for reporting state, and FALSE to use the polling model.)
        /// See ReportState : https://developers.google.com/actions/smarthome/report-state
        /// </summary>
        public bool willReportState { get; set; }

        /// <summary>
        /// String. Optional. Provides the current room of the device in the user's home to simplify setup.
        /// </summary>
        public string roomHint { get; set; }

        /// <summary>
        /// Object. Optional. Contains fields describing the device for use in one-off logic if needed (e.g. 'broken firmware version X of light Y requires adjusting color', or 'security ﬂaw requires notifying all users of firmware Z').
        /// </summary>
        public DeviceInfo deviceInfo { get; set; }

        /// <summary>
        /// Object. Optional, aligned with per-trait attributes as in Attributes below. Right-hand values are string | int | boolean | number.
        /// </summary>
        public object attributes { get; set; }

        /// <summary>
        /// Object. Optional; this is a special object defined by the partner which will be attached to future QUERY and EXECUTE requests. Partners can use this object to store additional information about the device to improve performance or routing within their cloud, such as the global region of the device. Data in this object has a few constraints:
        /// -No Personally Identifiable Information.
        /// -Data should change rarely, akin to other attributes -- so this should not contain real-time state.
        /// -The total object is limited to 512 bytes per device.
        /// </summary>
        public object customData { get; set; }
    }
}
