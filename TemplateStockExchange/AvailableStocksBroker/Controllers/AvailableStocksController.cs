using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvailableStocksBroker.Data;
using AvailableStocksBroker.Models;

namespace AvailableStocksBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableStocksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvailableStocksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AvailableStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableStock>>> GetAvailableStock()
        {
            return await _context.AvailableStock.ToListAsync();
        }

        // GET: api/AvailableStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvailableStock>> GetAvailableStock(int id)
        {
            var availableStock = await _context.AvailableStock.FindAsync(id);

            if (availableStock == null)
            {
                return NotFound();
            }

            return availableStock;
        }

        // PUT: api/AvailableStocks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailableStock(int id, AvailableStock availableStock)
        {
            if (id != availableStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(availableStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableStockExists(id))
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

        // POST: api/AvailableStocks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AvailableStock>> PostAvailableStock(AvailableStock availableStock)
        {
            _context.Add(availableStock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType()); // what is the real exception?
            }
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailableStock", new { id = availableStock.Id }, availableStock);
        }

        // DELETE: api/AvailableStocks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AvailableStock>> DeleteAvailableStock(int id)
        {
            var availableStock = await _context.AvailableStock.FindAsync(id);
            if (availableStock == null)
            {
                return NotFound();
            }

            _context.AvailableStock.Remove(availableStock);
            await _context.SaveChangesAsync();

            return availableStock;
        }

        private bool AvailableStockExists(int id)
        {
            return _context.AvailableStock.Any(e => e.Id == id);
        }
    }
}
