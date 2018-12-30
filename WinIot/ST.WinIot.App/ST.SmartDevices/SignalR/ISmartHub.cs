using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ST.SmartDevices.SignalR
{
    public interface ISmartHub
    {
        Task NewGoogleAction(Guid DeviceId, string Action);
        Task DeviceChanged(Guid DeviceId);
        
    }
}
