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
    public class TariffController : ControllerBase
    {
        private readonly AirbnbContext _context;

        public TariffController(AirbnbContext context)
        {
            _context = context;
        }

        // GET: api/Tariff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tariff>>> GetPricings()
        {
            return await _context.Pricings.ToListAsync();
        }

        // GET: api/Tariff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tariff>> GetTariff(int id)
        {
            var tariff = await _context.Pricings.FindAsync(id);

            if (tariff == null)
            {
                return NotFound();
            }

            return tariff;
        }

        // PUT: api/Tariff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTariff(int id, Tariff tariff)
        {
            if (id != tariff.PriceId)
            {
                return BadRequest();
            }

            _context.Entry(tariff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TariffExists(id))
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

        // POST: api/Tariff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tariff>> PostTariff(Tariff tariff)
        {
            _context.Pricings.Add(tariff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTariff", new { id = tariff.PriceId }, tariff);
        }

        // DELETE: api/Tariff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTariff(int id)
        {
            var tariff = await _context.Pricings.FindAsync(id);
            if (tariff == null)
            {
                return NotFound();
            }

            _context.Pricings.Remove(tariff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TariffExists(int id)
        {
            return _context.Pricings.Any(e => e.PriceId == id);
        }
    }
}
