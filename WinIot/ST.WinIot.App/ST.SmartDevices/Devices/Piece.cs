using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Piece : IOwned
    {
        public Guid PieceId { get; set; }
        public Guid HomeId { get; set; }

        public virtual Home Home { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
        public int Floor { get; set; }
        public enum TypeEnum {
            Kitchen = 1,
            Master_Bedroom,
            Bedroom,
            Living_Room,
            BathRoom
        }
    }
}
