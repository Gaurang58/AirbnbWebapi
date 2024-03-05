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
    public class OrderConfirmationController : ControllerBase
    {
        private readonly AirbnbContext _context;

        public OrderConfirmationController(AirbnbContext context)
        {
            _context = context;
        }

        // GET: api/OrderConfirmation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderConfirmation>>> GetOrderConfirmation()
        {
            return await _context.OrderConfirmation.ToListAsync();
        }

        // GET: api/OrderConfirmation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderConfirmation>> GetOrderConfirmation(string id)
        {
            var orderConfirmation = await _context.OrderConfirmation.FindAsync(id);

            if (orderConfirmation == null)
            {
                return NotFound();
            }

            return orderConfirmation;
        }

        // PUT: api/OrderConfirmation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderConfirmation(string id, OrderConfirmation orderConfirmation)
        {
            if (id != orderConfirmation.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderConfirmation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderConfirmationExists(id))
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

        // POST: api/OrderConfirmation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderConfirmation>> PostOrderConfirmation(OrderConfirmation orderConfirmation)
        {
            _context.OrderConfirmation.Add(orderConfirmation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderConfirmationExists(orderConfirmation.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderConfirmation", new { id = orderConfirmation.OrderId }, orderConfirmation);
        }

        // DELETE: api/OrderConfirmation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderConfirmation(string id)
        {
            var orderConfirmation = await _context.OrderConfirmation.FindAsync(id);
            if (orderConfirmation == null)
            {
                return NotFound();
            }

            _context.OrderConfirmation.Remove(orderConfirmation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderConfirmationExists(string id)
        {
            return _context.OrderConfirmation.Any(e => e.OrderId == id);
        }
    }
}
