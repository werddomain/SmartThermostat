using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ST.Web.OAuth.Controllers
{
    public class ClientsController : Controller
    {
        private IApplicationLifetime ApplicationLifetime { get; set; }

        public ClientsController(IApplicationLifetime appLifetime)
        {
            ApplicationLifetime = appLifetime;
        }
        /// <summary>
        /// When some chan ges are made in the application than need the application to restart, we can use this method to shut it down. In windows, IIS will restart the applcation when a new request is received.
        /// </summary>
        private void Restart() {
            ApplicationLifetime.StopApplication();
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}