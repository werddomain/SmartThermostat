using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Google.PayLoads
{
    public class DeviceExecuteResponsePayload:PayLoadBase
    {
        public DeviceExecuteResponseCommand[] commands { get; set; }
    }
    public class DeviceExecuteResponseCommand {
        public DeviceExecuteResponseCommand() { }
        public DeviceExecuteResponseCommand(statusEnum Status) {
            status = Status.ToString();
        }
        public string[] ids { get; set; }
        public string status { get; set; }
        public string errorCode { get; set; }
        public string debugString { get; set; }

        public object states { get; set; }
        public enum statusEnum {
            SUCCESS,
            PENDING,
            OFFLINE,
            ERROR
        }
    }
}
