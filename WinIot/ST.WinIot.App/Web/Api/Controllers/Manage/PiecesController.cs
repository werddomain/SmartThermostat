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
	public class PiecesController : BaseApiController
	{
        private readonly DeviceDataContext _context;

        public PiecesController(DeviceDataContext context)
        {
            _context = context;
        }

        // GET: api/Pieces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piece>>> GetPieces()
        {
            return await _context.Pieces.Where(o=>o.UserId == GetUserId()).ToListAsync();
        }

        // GET: api/Pieces/5
        [HttpGet("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Piece>> GetPiece(Guid id)
        {
            var piece = await _context.Pieces.FindAsync(id);

            if (piece == null)
            {
                return NotFound();
            }

			if (!Owned(piece))
				return Unauthorized();

            return piece;
        }

        // PUT: api/Pieces/5
        [HttpPut("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<IActionResult> PutPiece(Guid id, Piece piece)
        {
            if (id != piece.PieceId)
            {
                return BadRequest();
            }
			var original = await _context.Pieces.FindAsync(id);
			if (original == null)
				return NotFound();
			if (!Owned(original))
				return Unauthorized();
			_context.Entry(piece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceExists(id))
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

        // POST: api/Pieces
        [HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		public async Task<ActionResult<Piece>> PostPiece(Piece piece)
        {
			piece.PieceId = Guid.NewGuid();
			piece.UserId = GetUserId();
            _context.Pieces.Add(piece);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiece", new { id = piece.PieceId }, piece);
        }

        // DELETE: api/Pieces/5
        [HttpDelete("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public async Task<ActionResult<Piece>> DeletePiece(Guid id)
        {
            var piece = await _context.Pieces.FindAsync(id);
            if (piece == null)
            {
                return NotFound();
            }
			if (!Owned(piece))
				return Unauthorized();

            _context.Pieces.Remove(piece);
            await _context.SaveChangesAsync();

            return piece;
        }

        private bool PieceExists(Guid id)
        {
            return _context.Pieces.Any(e => e.PieceId == id);
        }
    }
}
