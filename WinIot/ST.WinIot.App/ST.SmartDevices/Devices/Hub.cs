using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    [ApiModel]
    public class Hub : IOwned
    {
		/// <summary>
		/// Db Key
		/// </summary>
		public Guid HubId { get; set; }

		/// <summary>
		/// UserId Guid. Will be overwrited on Insert and Update by the current userid
		/// </summary>
		[Required]
        public string UserId { get; set; }
        public Guid HomeId { get; set; }
		/// <summary>
		/// The hardware the hub is hosted on. Usually a Rapsberry Pie [Zero, 2 or 3]
		/// </summary>
        public string Hardware { get; set; }

		/// <summary>
		/// The Piece the hub is setup in.
		/// </summary>
        public Guid PieceId { get; set; }

        public virtual Piece Piece { get; set; }

		/// <summary>
		/// Devices controlled by this Hub. It will give you devices in connected relays to.
		/// </summary>
        public ICollection<Device> Devices { get; set; }

		/// <summary>
		/// Relays connected to this hub.
		/// </summary>
        public ICollection<Relay> Relays { get; set; }


    }
}
