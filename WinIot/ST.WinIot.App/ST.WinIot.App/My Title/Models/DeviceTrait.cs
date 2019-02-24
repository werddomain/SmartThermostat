﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace ST.WinIot.App.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class DeviceTrait
    {
        /// <summary>
        /// Initializes a new instance of the DeviceTrait class.
        /// </summary>
        public DeviceTrait() { }

        /// <summary>
        /// Initializes a new instance of the DeviceTrait class.
        /// </summary>
        public DeviceTrait(string deviceTraitId = default(string), string displayName = default(string), string description = default(string))
        {
            DeviceTraitId = deviceTraitId;
            DisplayName = displayName;
            Description = description;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deviceTraitId")]
        public string DeviceTraitId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
