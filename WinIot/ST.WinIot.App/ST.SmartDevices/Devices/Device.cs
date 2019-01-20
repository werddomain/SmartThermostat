using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    [ApiModel]
    public class Device: IOwned
    {
		/// <summary>
		/// Db Key
		/// </summary>
        public Guid DeviceId { get; set; }

		/// <summary>
		/// UserId Guid. Will be overwrited on Insert and Update by the current userid
		/// </summary>
        public string UserId { get; set; }
		/// <summary>
		/// If this device use an arduino as a relay to comunicate with the hub, this is the arduino RelayId
		/// </summary>
        public Guid? RelayId { get; set; }

		/// <summary>
		/// The Hub, usually the RaspberryPie
		/// </summary>
        public Guid HubId { get; set; }

		/// <summary>
		/// The piece this device is in.
		/// </summary>
        public Guid PieceId { get; set; }
        
		/// <summary>
		/// The device Name. It will be the name used by Vocal Assistant to.
		/// </summary>
        [Required]
        public string Name { get; set; }

		/// <summary>
		/// This is the number inside the arduino responsable to control the device. It will be set automaticly. Dont change this id.
		/// </summary>
        [Required]
        public int? ArduinoId { get; set; }

		/// <summary>
		/// The google Device Type
		/// </summary>
        public Google.DeviceType DeviceType { get; set; }

		/// <summary>
		/// The google device capability (Traits)
		/// </summary>
		public ICollection<Google.DeviceTrait> Traits { get; set; }

		/// <summary>
		/// Others names given to Vocal Assistant to call this device 
		/// </summary>
        public ICollection<DeviceNickName> NickNames { get; set; }

		[JsonIgnore]
		public Hub Hub { get; set; }

		[JsonIgnore]
		public Relay Relay { get; set; }

		[JsonIgnore]
		public Piece Piece { get; set; }
    }
}
