// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ST.Web.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            debug("get");

            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpPost]
        public IActionResult Post()
        {
            debug("post");
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        void debug(string From) {

        }
    }
}