using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Piece
    {
        public Guid Id { get; set; }
        public Guid HomeId { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public TypeEnum Type { get; set; }
        public string Floor { get; set; }
        public enum TypeEnum {
            Kitchen = 1,
            Master_Bedroom,
            Bedroom,
            Living_Room,
            BathRoom
        }
    }
}
