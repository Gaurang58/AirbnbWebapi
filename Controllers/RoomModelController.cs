using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airbnb.Models;

namespace Airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomModelController : ControllerBase
    {
        private readonly AirbnbContext _context;

        public RoomModelController(AirbnbContext context)
        {
            _context = context;
        }

        // GET: api/RoomModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomModel>>> GetRoomModels()
        {
            return await _context.RoomModels.ToListAsync();
        }

        // GET: api/RoomModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetRoomModel(int id)
        {
            var roomModel = await _context.RoomModels.FindAsync(id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return roomModel;
        }

        // PUT: api/RoomModel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomModel(int id, RoomModel roomModel)
        {
            if (id != roomModel.RoomModelId)
            {
                return BadRequest();
            }

            _context.Entry(roomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomModelExists(id))
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

        // POST: api/RoomModel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomModel>> PostRoomModel(RoomModel roomModel)
        {
            _context.RoomModels.Add(roomModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomModel", new { id = roomModel.RoomModelId }, roomModel);
        }

        // DELETE: api/RoomModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomModel(int id)
        {
            var roomModel = await _context.RoomModels.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }

            _context.RoomModels.Remove(roomModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomModelExists(int id)
        {
            return _context.RoomModels.Any(e => e.RoomModelId == id);
        }
    }
}
