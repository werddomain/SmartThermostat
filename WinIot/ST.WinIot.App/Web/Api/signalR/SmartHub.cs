using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using ST.SmartDevices.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.signalR
{
    [Authorize]
    public class SmartHub: Hub<ISmartHub>
    {
        //https://docs.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-2.2
        //https://github.com/IdentityServer/IdentityServer4/issues/2349
        //https://stackoverflow.com/questions/52247575/api-using-signalr-with-identityserver4-hangs-on-3-conections?noredirect=1#comment94792585_52247575
        //Here the client dont send anything. It listen for commands to execute.
        
    }
}
