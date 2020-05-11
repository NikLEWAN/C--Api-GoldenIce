using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenIce.Models;

namespace GoldenIce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamOrdersController : ControllerBase
    {
        private readonly IceCreamOrderContext _context;

        public IceCreamOrdersController(IceCreamOrderContext context)
        {
            _context = context;
        }

        // GET: api/IceCreamOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IceCreamOrder>>> GetIceCreamOrders()
        {
            return await _context.IceCreamOrders.ToListAsync();
        }

        // GET: api/IceCreamOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IceCreamOrder>> GetIceCreamOrder(long id)
        {
            var iceCreamOrder = await _context.IceCreamOrders.FindAsync(id);

            if (iceCreamOrder == null)
            {
                return NotFound();
            }

            return iceCreamOrder;
        }

        // PUT: api/IceCreamOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIceCreamOrder(long id, IceCreamOrder iceCreamOrder)
        {
            if (id != iceCreamOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(iceCreamOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IceCreamOrderExists(id))
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

        // POST: api/IceCreamOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IceCreamOrder>> PostIceCreamOrder(IceCreamOrder iceCreamOrder)
        {
            _context.IceCreamOrders.Add(iceCreamOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIceCreamOrder", new { id = iceCreamOrder.Id }, iceCreamOrder);
        }

        // DELETE: api/IceCreamOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IceCreamOrder>> DeleteIceCreamOrder(long id)
        {
            var iceCreamOrder = await _context.IceCreamOrders.FindAsync(id);
            if (iceCreamOrder == null)
            {
                return NotFound();
            }

            _context.IceCreamOrders.Remove(iceCreamOrder);
            await _context.SaveChangesAsync();

            return iceCreamOrder;
        }

        private bool IceCreamOrderExists(long id)
        {
            return _context.IceCreamOrders.Any(e => e.Id == id);
        }
    }
}
