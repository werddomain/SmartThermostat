using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    [ApiModel]
    public class DeviceNickName
    {
        public Guid DeviceNickNameId { get; set; }
        public Guid DeviceId { get; set; }
        public string NickName { get; set; }

    }
}
