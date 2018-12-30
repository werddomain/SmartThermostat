using Microsoft.AspNetCore.SignalR;
using ST.SmartDevices.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.signalR
{
    public class SmartHub: Hub<ISmartHub>
    {
        //https://docs.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-2.2
        //https://github.com/IdentityServer/IdentityServer4/issues/2349
    }
}
