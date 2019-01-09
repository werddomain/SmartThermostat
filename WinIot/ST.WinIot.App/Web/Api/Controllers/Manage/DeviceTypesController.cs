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
	public class DeviceTypesController : BaseApiController
	{
        private readonly DeviceDataContext _context;

        public DeviceTypesController(DeviceDataContext context)
        {
            _context = context;
        }

        // GET: api/DeviceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceType>>> GetDeviceTypes()
        {
            return await _context.DeviceTypes.ToListAsync();
        }

        //// GET: api/DeviceTypes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DeviceType>> GetDeviceType(string id)
        //{
        //    var deviceType = await _context.DeviceTypes.FindAsync(id);

        //    if (deviceType == null)
        //    {
        //        return NotFound();
        //    }

        //    return deviceType;
        //}

        //// PUT: api/DeviceTypes/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDeviceType(string id, DeviceType deviceType)
        //{
        //    if (id != deviceType.DeviceTypeId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(deviceType).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeviceTypeExists(id))
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

        //// POST: api/DeviceTypes
        //[HttpPost]
        //public async Task<ActionResult<DeviceType>> PostDeviceType(DeviceType deviceType)
        //{
        //    _context.DeviceTypes.Add(deviceType);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDeviceType", new { id = deviceType.DeviceTypeId }, deviceType);
        //}

        //// DELETE: api/DeviceTypes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<DeviceType>> DeleteDeviceType(string id)
        //{
        //    var deviceType = await _context.DeviceTypes.FindAsync(id);
        //    if (deviceType == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DeviceTypes.Remove(deviceType);
        //    await _context.SaveChangesAsync();

        //    return deviceType;
        //}

        private bool DeviceTypeExists(string id)
        {
            return _context.DeviceTypes.Any(e => e.DeviceTypeId == id);
        }
    }
}
