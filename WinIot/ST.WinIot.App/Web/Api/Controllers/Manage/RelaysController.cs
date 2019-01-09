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
	public class RelaysController : BaseApiController
	{
        private readonly DeviceDataContext _context;

        public RelaysController(DeviceDataContext context)
        {
            _context = context;
        }

        // GET: api/Relays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relay>>> GetRelays()
        {
            return await _context.Relays.Where(o=>o.UserId == GetUserId()).ToListAsync();
        }

        // GET: api/Relays/5
        [HttpGet("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Relay>> GetRelay(Guid id)
        {
            var relay = await _context.Relays.FindAsync(id);

            if (relay == null)
            {
                return NotFound();
            }
			if (relay.UserId != GetUserId())
				return Unauthorized();

            return relay;
        }

        // PUT: api/Relays/5
        [HttpPut("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<IActionResult> PutRelay(Guid id, Relay relay)
        {
            if (id != relay.RelayId)
            {
                return BadRequest();
            }
			var original = await _context.Relays.FindAsync(id);
			if (original == null)
				return NotFound();
			if (!Owned(original))
				return Unauthorized();

            _context.Entry(relay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelayExists(id))
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

        // POST: api/Relays
        [HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		public async Task<ActionResult<Relay>> PostRelay(Relay relay)
        {
			relay.RelayId = Guid.NewGuid();
			relay.UserId = GetUserId();
            _context.Relays.Add(relay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelay", new { id = relay.RelayId }, relay);
        }

        // DELETE: api/Relays/5
        [HttpDelete("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Relay>> DeleteRelay(Guid id)
        {
            var relay = await _context.Relays.FindAsync(id);
            if (relay == null)
            {
                return NotFound();
            }
			if (!Owned(relay))
				return Unauthorized();

            _context.Relays.Remove(relay);
            await _context.SaveChangesAsync();

            return relay;
        }

        private bool RelayExists(Guid id)
        {
            return _context.Relays.Any(e => e.RelayId == id);
        }
    }
}
