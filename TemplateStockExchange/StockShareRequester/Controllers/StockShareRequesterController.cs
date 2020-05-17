using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockShareRequester.Data;
using StockShareRequester.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace StockShareRequester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockShareRequesterController : ControllerBase
    {
        private readonly AppDbContext _context;
        static HttpClient client = new HttpClient();
        private readonly string ip = "https://localhost:44336/";
        

        public StockShareRequesterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StockShareRequester
        [HttpGet]
        public async Task<HttpStatusCode> GetStock()
        {
            HttpResponseMessage response;

            using ( client )
            {
                client.BaseAddress = new Uri(ip);
                Stock stock = new Stock(3, 100, "myStock", 10, "Florent", "Thomas", DateTime.Now);
                response = await client.PostAsJsonAsync("api/AvailableStocks", stock);
            }
           

            return response.StatusCode;
        }

        // GET: api/StockShareRequester/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/StockShareRequester/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.Id)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/StockShareRequester
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
        }

        // DELETE: api/StockShareRequester/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stock>> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        private bool StockExists(int id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }
    }
}
