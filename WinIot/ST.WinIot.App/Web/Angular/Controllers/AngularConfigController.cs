using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ST.Web.Angular.Controllers
{
  [Route("config/[controller]")]
  [ApiController]
  [ST.SmartDevices.GenerateApi]
  public class AngularController : ControllerBase
  {
    [HttpGet]
    [Route("GetAuth")]
    public ActionResult<MyAngularConfig> GetAuth()
    {
      return new MyAngularConfig();
    }
  }
}
