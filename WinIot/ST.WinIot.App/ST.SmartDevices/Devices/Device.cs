using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Device
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? RelayId { get; set; }
        public Guid HubId { get; set; }

        public string Name { get; set; }
        public int ArduinoId { get; set; }

    }
}
