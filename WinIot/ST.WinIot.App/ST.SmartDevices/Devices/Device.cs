using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Device
    {
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public Guid? RelayId { get; set; }
        public Guid HubId { get; set; }

        public Guid PieceId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int? ArduinoId { get; set; }

        public Hub Hub { get; set; }
        public Relay Relay { get; set; }
        public Piece Piece { get; set; }
    }
}
