using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public class Hub
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid HomeId { get; set; }
        public string Hardware { get; set; }
        public Guid PieceId { get; set; }

    }
}
