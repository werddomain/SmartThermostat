using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    [ApiModel]
    public class Piece : IOwned
    {
		/// <summary>
		/// Db Key
		/// </summary>
		public Guid? PieceId { get; set; }
        public Guid HomeId { get; set; }

        public virtual Home Home { get; set; }

		/// <summary>
		/// UserId Guid. Will be overwrited on Insert and Update by the current userid
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Piece name given to Voice Assistant to help you to setup devices
		/// </summary>
        [Required]
        public string Name { get; set; }

		/// <summary>
		/// Piece type given to voice assistant to suggest new activities and scenes
		/// </summary>
		[Required]
		public PieceTypeEnum Type { get; set; }

		/// <summary>
		/// Used by temperature controller to help to build a mesh of the temperature in the home
		/// </summary>
        public int Floor { get; set; }
        
    }
    
}
