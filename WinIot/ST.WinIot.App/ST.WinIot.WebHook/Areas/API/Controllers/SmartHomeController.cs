using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ST.WinIot.WebHook.Areas.API.Controllers
{
    public class SmartHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}