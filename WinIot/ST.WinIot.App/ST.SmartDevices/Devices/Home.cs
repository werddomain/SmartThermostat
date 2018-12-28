using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Home
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
