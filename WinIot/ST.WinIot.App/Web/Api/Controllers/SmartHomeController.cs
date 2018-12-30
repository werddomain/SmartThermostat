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
using Microsoft.AspNetCore.SignalR;

namespace ST.Web.API.Controllers
{
    [Route("[controller]/fulfillment")]
    [ApiController]
    [Authorize]
    //DOC: https://developers.google.com/actions/smarthome/create#request
    public class SmartHomeController : BaseApiController
    {
        Data.DeviceDataContext DataContext { get; set; }
        IHubContext<signalR.SmartHub, SmartDevices.SignalR.ISmartHub> SmartHubContext;
        public SmartHomeController(Data.DeviceDataContext deviceDataContext, IHubContext<signalR.SmartHub, SmartDevices.SignalR.ISmartHub> smartHubContext) {
            DataContext = deviceDataContext;
            SmartHubContext = smartHubContext;
        }
        [HttpGet]
        public IActionResult get() {
            debug("get");
            return NotFound();
        }

        [HttpPost]
        [Produces("application/json")]
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
        
        const bool HomeGraphReportEnabled = false;
        bool willReportState(SmartDevices.Devices.Device device) {
            return HomeGraphReportEnabled && device.DeviceType.DeviceTypeId != SmartDevices.Google.action.devices.types.SCENE;
        }

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
                                    willReportState = willReportState(e)

                                };
            response.payload.devices = googleDevices?.ToArray();
            response.payload.agentUserId = UserId;
            return Ok(response);
        }
        async Task<IActionResult> QUERY(GoogleRequest request)
        {
            //https://developers.google.com/actions/smarthome/create#actiondevicesquery
            var payload = request.inputs.First().payload as PayLoads.DevicesQueryInputPayload;
            var response = new GoogleResponse<PayLoads.DeviceQueryPayload>(request);

            return Ok(response);
        }
        async Task<IActionResult> EXECUTE(GoogleRequest request)
        {
            //https://developers.google.com/actions/smarthome/create#actiondevicesexecute
            var userId = GetUserId();
            var userChannel = SmartHubContext.Clients.User(userId);
            if (userChannel != null)
            await userChannel.NewGoogleAction(Guid.Empty, "");
            var response = new GoogleResponse<PayLoads.DeviceExecuteResponsePayload>(request);
            return Ok(response);
        }
        async Task<IActionResult> DISCONNECT(GoogleRequest request)
        {
            //https://developers.google.com/actions/smarthome/create#actiondevicesdisconnect
            return new JsonResult(new { });
        }
        void debug(string From)
        {

        }
    }
}