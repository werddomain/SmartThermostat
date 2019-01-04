using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices.Google
{
    [ApiModel]
    public class DeviceTrait
    {
        public string DeviceTraitId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
