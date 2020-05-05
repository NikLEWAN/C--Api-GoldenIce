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
    public class IceCreamsController : ControllerBase
    {
        private readonly IceCreamContext _context;

        public IceCreamsController(IceCreamContext context)
        {
            _context = context;
        }

        // GET: api/IceCreams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IceCream>>> GetIceCreams()
        {
            return await _context.IceCreams.ToListAsync();
        }

        // GET: api/IceCreams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IceCream>> GetIceCream(long id)
        {
            var iceCream = await _context.IceCreams.FindAsync(id);

            if (iceCream == null)
            {
                return NotFound();
            }

            return iceCream;
        }

        // PUT: api/IceCreams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIceCream(long id, IceCream iceCream)
        {
            if (id != iceCream.Id)
            {
                return BadRequest();
            }

            _context.Entry(iceCream).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IceCreamExists(id))
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

        // POST: api/IceCreams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IceCream>> PostIceCream(IceCream iceCream)
        {
            _context.IceCreams.Add(iceCream);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetIceCream), new { id = iceCream.Id }, iceCream);
        }

        // DELETE: api/IceCreams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IceCream>> DeleteIceCream(long id)
        {
            var iceCream = await _context.IceCreams.FindAsync(id);
            if (iceCream == null)
            {
                return NotFound();
            }

            _context.IceCreams.Remove(iceCream);
            await _context.SaveChangesAsync();

            return iceCream;
        }

        private bool IceCreamExists(long id)
        {
            return _context.IceCreams.Any(e => e.Id == id);
        }
    }
}
