using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserStocksBroker.Data;
using UserStocksBroker.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace UserStocksBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStocksBrokerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private static HttpClient client = new HttpClient();
        private readonly string userControllerIp = "https://localhost:58270/";

        public UserStocksBrokerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserStocksBroker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStock()
        {
            return await _context.Stock.ToListAsync();
        }

        // GET: api/UserStocksBroker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _context.Stock.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/UserStocksBroker/5
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

        // POST: api/UserStocksBroker
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            _context.Stock.Add(stock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockExists(stock.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
        }

        // DELETE: api/UserStocksBroker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stock>> DeleteStock(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.Id == id);
        }

        // Used for when you want to post a stock to the USB database, when a stock is bought
        [HttpPost("{userId}")]
        public async Task<HttpStatusCode> BuyStock(int userId, Stock stock)
        {
            Stock newStock = new Stock(stock.Id, stock.Price, stock.FullPrice, stock.Name, stock.Quantity, stock.Seller, stock.Buyer, stock.TimeStamp, userId);

            HttpResponseMessage response;

            _context.Add(newStock);

            await _context.SaveChangesAsync();

            using (client)
            {
                client.BaseAddress = new Uri(userControllerIp);
                response = await client.PutAsJsonAsync("api/UserController/" + userId, stock);
            }

            return response.StatusCode;
        }

        // Used for when you want to sell a stock and therefore delete it for your portfolio
        [HttpDelete("{userId}")]
        public async Task<HttpStatusCode> SellStock(int userId, Stock stock)
        {
            var query = await _context.Stock.Where(s => s.Id == stock.Id).FirstOrDefaultAsync();

            HttpResponseMessage response;

            if(query != null)
            {
                _context.Remove(query);
            }
            else
            {
                Console.WriteLine("Error, no stock found");
            }

            using (client)
            {
                client.BaseAddress = new Uri(userControllerIp);
                response = await client.PutAsJsonAsync("api/UserController/" + userId, stock);
            }

            return response.StatusCode;            
        }
    }
}
