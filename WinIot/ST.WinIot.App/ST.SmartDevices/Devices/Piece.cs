using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    [ApiModel]
    public class Piece : IOwned
    {
        public Guid? PieceId { get; set; }
        public Guid HomeId { get; set; }

        public virtual Home Home { get; set; }

        
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
		[Required]
		public PieceTypeEnum Type { get; set; }
        public int Floor { get; set; }
        
    }
    
}
