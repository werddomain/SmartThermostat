using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ST.Web.Angular.Controllers
{
    public class ngController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}