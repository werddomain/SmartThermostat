using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ST.SmartDevices.Devices
{
    [ApiModel]
    public class Home : IOwned
    {
		/// <summary>
		/// Db Key
		/// </summary>
		public Guid? HomeId { get; set; }

		/// <summary>
		/// UserId Guid. Will be overwrited on Insert and Update by the current userid
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Home Name. In case you control more than one home.
		/// </summary>
        [Required]
        public string Name { get; set; }

		/// <summary>
		/// Full Street address used to get whether and others informations to the Hub
		/// </summary>
        [Required]
        public string FullAddress { get; set; }

		/// <summary>
		/// City used to get whether and others informations to the Hub
		/// </summary>
		[Required]
        public string City { get; set; }

		/// <summary>
		/// State used to get whether and others informations to the Hub
		/// </summary>
		[Required]
        public string State { get; set; }

		/// <summary>
		/// Country used to get whether and others informations to the Hub
		/// </summary>
		[Required]
        public string Country { get; set; }

		[JsonIgnore]
		public ICollection<Hub> Hubs { get; set; }
		[JsonIgnore]
		public ICollection<Piece> Pieces { get; set; }


    }
}
