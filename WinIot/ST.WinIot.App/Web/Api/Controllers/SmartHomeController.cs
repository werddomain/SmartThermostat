using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST.Web.API.Attributes;
using ST.Web.API.GoogleSmartHomeModel;

namespace ST.Web.API.Controllers
{
    [Route("[controller]/fulfillment")]
    [ApiController]
    [Authorize]
    //DOC: https://developers.google.com/actions/smarthome/create#request
    public class SmartHomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult get() {
            debug("get");
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(GoogleRequest request)
        {
            debug("post");
            switch (request.inputs.First().intent)
            {
                case action.devices.SYNC:
                    return SYNC(request);

                case action.devices.QUERY:
                    return QUERY(request);

                case action.devices.EXECUTE:
                    return EXECUTE(request);

                case action.devices.DISCONNECT:
                    return DISCONNECT(request);
                default:
                    return NotFound();
            }
        }
        IActionResult SYNC(GoogleRequest request) {
            var response = new GoogleResponse<DevicesSYNCPayLoad>(request);

        }
        IActionResult QUERY(GoogleRequest request)
        {

        }
        IActionResult EXECUTE(GoogleRequest request)
        {

        }
        IActionResult DISCONNECT(GoogleRequest request)
        {

        }
        void debug(string From)
        {

        }
    }
}