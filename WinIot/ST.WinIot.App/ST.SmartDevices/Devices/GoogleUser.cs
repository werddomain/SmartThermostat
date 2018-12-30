using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class GoogleUser : IOwned
    {
        public Guid GoogleUserId { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
        public DateTime ActivationDate { get; set; }

    }
}
