using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ST.WinIot.WebHook.Areas.API.Controllers
{
    //Docs : https://developers.google.com/actions/smarthome/create?hl=fr#request
    [Authorize]
    public class SmartHomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }

        public IActionResult fulfillment(Object posted)
        {
            return Ok();
        }

    }
}