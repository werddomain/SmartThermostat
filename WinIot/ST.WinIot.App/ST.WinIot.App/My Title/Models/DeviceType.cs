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

    public partial class DeviceType
    {
        /// <summary>
        /// Initializes a new instance of the DeviceType class.
        /// </summary>
        public DeviceType() { }

        /// <summary>
        /// Initializes a new instance of the DeviceType class.
        /// </summary>
        public DeviceType(string deviceTypeId = default(string), string displayName = default(string), string description = default(string), IList<DeviceTrait> recommendedTraits = default(IList<DeviceTrait>))
        {
            DeviceTypeId = deviceTypeId;
            DisplayName = displayName;
            Description = description;
            RecommendedTraits = recommendedTraits;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deviceTypeId")]
        public string DeviceTypeId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "recommendedTraits")]
        public IList<DeviceTrait> RecommendedTraits { get; set; }

    }
}