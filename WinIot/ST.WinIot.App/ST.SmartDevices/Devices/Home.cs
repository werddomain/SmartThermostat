using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Home : IOwned
    {
        public Guid HomeId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string FullAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }


        public ICollection<Hub> Hubs { get; set; }
        public ICollection<Piece> Pieces { get; set; }


    }
}
