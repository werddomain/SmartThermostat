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
	public class DevicesController : BaseApiController
	{
        private readonly DeviceDataContext _context;

        public DevicesController(DeviceDataContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.Where(o => o.UserId == GetUserId()).ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Device>> GetDevice(Guid id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }
			if (!Owned(device))
				return Unauthorized();
            return device;
        }

        // PUT: api/Devices/5
        [HttpPut("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<IActionResult> PutDevice(Guid id, Device device)
        {
            if (id != device.DeviceId)
            {
                return BadRequest();
            }
			var original = await _context.Devices.FindAsync(id);
			if (original == null)
				return NotFound();
			if (!Owned(original))
				return Unauthorized();

			device.UserId = GetUserId();
			_context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Devices
        [HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		public async Task<ActionResult<Device>> PostDevice(Device device)
        {
			device.DeviceId = Guid.NewGuid();
			device.UserId = GetUserId();
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Device>> DeleteDevice(Guid id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
			if (!Owned(device))
				return Unauthorized();

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return device;
        }

        private bool DeviceExists(Guid id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }
}
