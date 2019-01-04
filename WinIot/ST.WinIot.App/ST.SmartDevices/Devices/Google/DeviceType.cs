using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices.Google
{
    [ApiModel]
    public class DeviceType
    {
        public string DeviceTypeId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public ICollection<DeviceTrait> RecommendedTraits { get; set; }

    }
}
