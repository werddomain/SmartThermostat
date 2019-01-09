using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST.SmartDevices;
using ST.SmartDevices.Devices.Google;
using ST.Web.API.Data;

namespace ST.Web.API.Controllers.Manage
{
	[Route("Manage/[controller]")]
	[ApiController]
	[Authorize]
	[GenerateApi]
	public class DeviceTraitsController : BaseApiController
	{
        private readonly DeviceDataContext _context;

        public DeviceTraitsController(DeviceDataContext context)
        {
            _context = context;
        }

        // GET: api/DeviceTraits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceTrait>>> GetDeviceTraits()
        {
            return await _context.DeviceTraits.ToListAsync();
        }

        //// GET: api/DeviceTraits/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DeviceTrait>> GetDeviceTrait(string id)
        //{
        //    var deviceTrait = await _context.DeviceTraits.FindAsync(id);

        //    if (deviceTrait == null)
        //    {
        //        return NotFound();
        //    }

        //    return deviceTrait;
        //}

        //// PUT: api/DeviceTraits/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDeviceTrait(string id, DeviceTrait deviceTrait)
        //{
        //    if (id != deviceTrait.DeviceTraitId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(deviceTrait).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeviceTraitExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/DeviceTraits
        //[HttpPost]
        //public async Task<ActionResult<DeviceTrait>> PostDeviceTrait(DeviceTrait deviceTrait)
        //{
        //    _context.DeviceTraits.Add(deviceTrait);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDeviceTrait", new { id = deviceTrait.DeviceTraitId }, deviceTrait);
        //}

        //// DELETE: api/DeviceTraits/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<DeviceTrait>> DeleteDeviceTrait(string id)
        //{
        //    var deviceTrait = await _context.DeviceTraits.FindAsync(id);
        //    if (deviceTrait == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DeviceTraits.Remove(deviceTrait);
        //    await _context.SaveChangesAsync();

        //    return deviceTrait;
        //}

        private bool DeviceTraitExists(string id)
        {
            return _context.DeviceTraits.Any(e => e.DeviceTraitId == id);
        }
    }
}
