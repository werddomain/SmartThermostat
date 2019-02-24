using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ST.Web.API.Controllers
{
    public class DefaultController : Controller
    {
		[HttpGet]
		[Route("/")]
		[Route("/[controller]")]
		public IActionResult Index()
        {
			//Redirect default to swagger
			return Redirect("/API/swagger/");
        }
    }
}