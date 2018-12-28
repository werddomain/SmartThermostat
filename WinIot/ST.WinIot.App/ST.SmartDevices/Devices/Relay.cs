using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Relay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HardWare { get; set; }

        public enum ConnectionType
        {
            Wifi,
            NRF24L01,
            I2C
        }
    }
}
