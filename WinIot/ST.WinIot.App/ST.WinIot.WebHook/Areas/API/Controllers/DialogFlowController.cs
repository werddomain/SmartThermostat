using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Dialogflow.v2;


namespace ST.WinIot.WebHook.Areas.API.Controllers
{
    //For use with https://console.dialogflow.com
    public class DialogFlowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}