using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    [ApiModel]
    public class Relay : IOwned
    {
		/// <summary>
		/// Db Key
		/// </summary>
		public Guid RelayId { get; set; }

		/// <summary>
		/// The hub Id this relay is connected to
		/// </summary>
        public Guid HubId { get; set; }
		[JsonIgnore]
		public virtual Hub Hub { get; set; }

		/// <summary>
		/// UserId Guid. Will be overwrited on Insert and Update by the current userid
		/// </summary>
		[Required]
        public string UserId { get; set; }

		/// <summary>
		/// The relay name. It's only to help you to figure what's this relay.
		/// </summary>
        [Required]
        public string Name { get; set; }

		/// <summary>
		/// Usually the type of hardware this relay is hosted on [Arduino Uno,Mega,Yun, etc..]
		/// </summary>
        public string HardWare { get; set; }

		/// <summary>
		/// The connection type used to communicate with the Hub
		/// </summary>
        public ConnectionTypeEnum ConnectionType { get; set; }

        
    }
   
}
