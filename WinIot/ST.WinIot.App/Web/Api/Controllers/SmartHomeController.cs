using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayLoads = ST.SmartDevices.Google.PayLoads;
using ST.Web.API.Attributes;
using ST.SmartDevices.Google;
using Microsoft.EntityFrameworkCore;

namespace ST.Web.API.Controllers
{
    [Route("[controller]/fulfillment")]
    [ApiController]
    [Authorize]
    //DOC: https://developers.google.com/actions/smarthome/create#request
    public class SmartHomeController : ControllerBase
    {
        Data.DeviceDataContext DataContext { get; set; }
        public SmartHomeController(Data.DeviceDataContext DeviceDataContext) {
            this.DataContext = DeviceDataContext;
        }
        [HttpGet]
        public IActionResult get() {
            debug("get");
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(GoogleRequest request)
        {
            debug("post");
            switch (request.inputs.First()?.intent)
            {
                case action.devices.SYNC:
                    return await SYNC(request);

                case action.devices.QUERY:
                    return await QUERY(request);

                case action.devices.EXECUTE:
                    return await EXECUTE(request);

                case action.devices.DISCONNECT:
                    return await DISCONNECT(request);
                default:
                    return NotFound();
            }
        }
        string GetUserId() {
            return User.Claims.FirstOrDefault(x => x.Type.Equals(JwtClaimTypes.Subject))?.Value;
        }
        const bool HomeGraphReportEnabled = false;
        async Task<IActionResult> SYNC(GoogleRequest request) {
            //https://developers.google.com/actions/smarthome/create#actiondevicessync
            var response = new GoogleResponse<PayLoads.DevicesSyncPayLoad>(request);
            var UserId = GetUserId();
            var GoogleUser = DataContext.GoogleUsers.FirstOrDefault(o => o.UserId == UserId);
            if (GoogleUser == null)
            {
                GoogleUser = new SmartDevices.Devices.GoogleUser
                {
                    GoogleUserId = Guid.NewGuid(),
                    UserId = UserId,
                    ActivationDate = DateTime.UtcNow,
                    Active = true
                };
                await DataContext.GoogleUsers.AddAsync(GoogleUser);
            }
            else
            {
                if (GoogleUser.Active == false)
                {
                    GoogleUser.Active = true;
                    GoogleUser.ActivationDate = DateTime.UtcNow;
                }
            }
            
            await DataContext.SaveChangesAsync();
            response.payload = new PayLoads.DevicesSyncPayLoad {
                agentUserId = UserId
            };
            var UserDevices = await DataContext.Devices.Where(o => o.UserId == UserId).ToListAsync();
            var googleDevices = from e in UserDevices
                                select new ST.SmartDevices.Google.DeviceSYNC {
                                    id = e.DeviceId.ToString(),
                                    name = new DeviceName {
                                         name = e.Name,
                                         nicknames = e.NickNames.Select(o=>o.NickName)?.ToArray()
                                    },
                                    roomHint = e.Piece.Name,
                                    traits = e.Traits.Select(o=>o.DeviceTraitId)?.ToArray(),
                                    type = e.DeviceType?.DeviceTypeId,
                                    willReportState = HomeGraphReportEnabled

                                };
            response.payload.devices = googleDevices?.ToArray();
            response.payload.agentUserId = UserId;
            return new JsonResult(response);
        }
        async Task<IActionResult> QUERY(GoogleRequest request)
        {
            //https://developers.google.com/actions/smarthome/create#actiondevicesquery
            var payload = request.inputs.First().payload as PayLoads.DevicesQueryInputPayload;
            var response = new GoogleResponse<PayLoads.DeviceQueryPayload>(request);


        }
        async Task<IActionResult> EXECUTE(GoogleRequest request)
        {
            //https://developers.google.com/actions/smarthome/create#actiondevicesexecute

        }
        async Task<IActionResult> DISCONNECT(GoogleRequest request)
        {
            //https://developers.google.com/actions/smarthome/create#actiondevicesdisconnect

        }
        void debug(string From)
        {

        }
    }
}