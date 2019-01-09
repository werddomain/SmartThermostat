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
	public class HubsController : BaseApiController
	{
		private readonly DeviceDataContext _context;

		public HubsController(DeviceDataContext context)
		{
			_context = context;
		}

		// GET: api/Hubs
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Hub>>> GetHubs()
		{
			return await _context.Hubs.Where(o => o.UserId == GetUserId()).ToListAsync();
		}

		// GET: api/Hubs/5
		[HttpGet("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Hub>> GetHub(Guid id)
		{
			var hub = await _context.Hubs.FindAsync(id);

			if (hub == null)
			{
				return NotFound();
			}
			if (!Owned(hub))
				return Unauthorized();

			return hub;
		}

		// PUT: api/Hubs/5
		[HttpPut("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<IActionResult> PutHub(Guid id, Hub hub)
		{
			if (id != hub.HubId)
			{
				return BadRequest();
			}

			var original = await _context.Hubs.FindAsync(id);
			if (original == null)
				return NotFound();
			if (!Owned(original))
				return Unauthorized();
			_context.Entry(hub).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!HubExists(id))
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

		// POST: api/Hubs
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		public async Task<ActionResult<Hub>> PostHub(Hub hub)
		{
			hub.HubId = Guid.NewGuid();
			hub.UserId = GetUserId();
			_context.Hubs.Add(hub);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetHub", new { id = hub.HubId }, hub);
		}

		// DELETE: api/Hubs/5
		[HttpDelete("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Hub>> DeleteHub(Guid id)
		{
			var hub = await _context.Hubs.FindAsync(id);
			if (hub == null)
			{
				return NotFound();
			}
			if (!Owned(hub))
				Unauthorized();

			_context.Hubs.Remove(hub);
			await _context.SaveChangesAsync();

			return hub;
		}

		private bool HubExists(Guid id)
		{
			return _context.Hubs.Any(e => e.HubId == id);
		}
	}
}
