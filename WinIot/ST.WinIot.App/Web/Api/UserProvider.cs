using IdentityModel;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API
{
    public class UserProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            var userId = connection.User.Claims.FirstOrDefault(x => x.Type.Equals(JwtClaimTypes.Subject))?.Value;
            return userId;
        }
    }
}
