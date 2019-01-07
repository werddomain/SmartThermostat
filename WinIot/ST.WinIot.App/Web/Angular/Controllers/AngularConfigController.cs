using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ST.Web.Angular.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [ST.SmartDevices.GenerateApi]
  public class AngularConfigController : ControllerBase
  {
    [HttpGet]
    [Route("GetAuth")]
    public ActionResult<MyAngularConfig> GetAuth()
    {
      return new MyAngularConfig();
    }
  }
}
