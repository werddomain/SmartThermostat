using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Hub
    {
        public Guid HubId { get; set; }

        [Required]
        public string UserId { get; set; }
        public Guid HomeId { get; set; }
        public string Hardware { get; set; }
        public Guid PieceId { get; set; }

        public virtual Piece Piece { get; set; }

        public ICollection<Device> Devices { get; set; }

        public ICollection<Relay> Relays { get; set; }


    }
}
