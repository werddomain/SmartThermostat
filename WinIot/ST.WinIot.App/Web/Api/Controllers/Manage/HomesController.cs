using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST.SmartDevices;
using ST.SmartDevices.Devices;
using ST.Web.API.Data;

namespace ST.Web.API.Controllers.Manage
{
    [Route("Manage/[controller]")]
    [ApiController]
    [Authorize]
	[GenerateApi]
    public class HomesController : BaseApiController
    {
        private readonly DeviceDataContext _context;
       
        public HomesController(DeviceDataContext context)
        {
            _context = context;
            
        }

        // GET: api/Homes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> GetHomes()
        {
            return await _context.Homes.Where(o=>o.UserId == GetUserId()).ToListAsync();
        }

        // GET: api/Homes/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Home>> GetHome(Guid id)
        {
            var home = await _context.Homes.FindAsync(id);
            
            if (home == null)
            {
                return NotFound();
            }
            if (!Owned(home))
                return Unauthorized();
            return home;
        }
        
        // PUT: api/Homes/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutHome(Guid id, Home home)
        {
            if (id != home.HomeId)
            {
                return BadRequest();
            }
            var original = await _context.Homes.FindAsync(id);
			if (original == null)
				return NotFound();
            if (!Owned(original))
                return Unauthorized();

            _context.Entry(home).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Homes
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<Home>> PostHome(Home home)
        {
			home.HomeId = Guid.NewGuid();
            home.UserId = GetUserId();
            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHome", new { id = home.HomeId }, home);
        }

        // DELETE: api/Homes/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Home>> DeleteHome(Guid id)
        {
            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            if (!Owned(home))
                return Unauthorized();
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return home;
        }

        private bool HomeExists(Guid id)
        {
            return _context.Homes.Any(e => e.HomeId == id);
        }
    }
}
