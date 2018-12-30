using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SmartDevices.Devices
{
    public interface IOwned
    {
        string UserId { get; set; }
    }
}
