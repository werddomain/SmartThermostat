using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Relay : IOwned
    {
        public Guid RelayId { get; set; }
        public Guid HubId { get; set; }

        public virtual Hub Hub { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
        public string HardWare { get; set; }


        public ConnectionTypeEnum ConnectionType { get; set; }

        public enum ConnectionTypeEnum
        {
            Wifi,
            NRF24L01,
            I2C
        }
    }
}
