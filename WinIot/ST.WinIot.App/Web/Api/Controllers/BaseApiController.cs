using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.Controllers
{
    // Api decoration swagger : https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-2.2&tabs=visual-studio%2Cvisual-studio-xml
    public abstract class BaseApiController: ControllerBase
    {
        string userId = null;
        protected string GetUserId()
        {
            if (userId == null)
            userId = User.Claims.FirstOrDefault(x => x.Type.Equals(JwtClaimTypes.Subject))?.Value;
            return userId;
        }
        protected bool Owned(SmartDevices.Devices.IOwned obj)
        {
            return (obj.UserId == GetUserId());
        }
    }
}
