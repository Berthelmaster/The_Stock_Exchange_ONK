using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvailableStocksBroker.Data;
using AvailableStocksBroker.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace AvailableStocksBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableStocksController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        private readonly AppDbContext _context;
        private readonly string TobinTaxIp = "https://localhost:44341/";
        private readonly string UserStocksIp = "https://localhost:44351/";

        public AvailableStocksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AvailableStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAvailableStocks()
        {
            return await _context.AvailableStocks.ToListAsync();
        }

        // GET: api/AvailableStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _context.AvailableStocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/AvailableStocks/5
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

        // POST: api/AvailableStocks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<HttpStatusCode> PostStock(Stock stock)
        {
            HttpResponseMessage responseMessageTobinTax;
            HttpResponseMessage responseMessageUserStocksDeleteStock;

            using (client)
            {
                client.BaseAddress = new Uri(TobinTaxIp);
                responseMessageTobinTax = client.PutAsJsonAsync("api/TobinTax/sell", stock).GetAwaiter().GetResult();
            }
            _context.AvailableStocks.Add(stock);
            await _context.SaveChangesAsync();


            if (responseMessageTobinTax.StatusCode == HttpStatusCode.OK)
            {
                string deleteCallUserStocks = "api/UserStocks";

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(UserStocksIp + deleteCallUserStocks),
                    Content = new StringContent(JsonConvert.SerializeObject(stock), Encoding.UTF8, "application/json")
                };

                responseMessageUserStocksDeleteStock = await client.SendAsync(request);

                _context.AvailableStocks.Add(stock);
                await _context.SaveChangesAsync();

                return responseMessageUserStocksDeleteStock.StatusCode;
            }

            return HttpStatusCode.InternalServerError;
        }

        // DELETE: api/AvailableStocks/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteStock(int id, Stock stock)
        {
            HttpResponseMessage responseMessageTobinTax;
            HttpResponseMessage responseMessageUserStocks;

            using (client)
            {
                client.BaseAddress = new Uri(TobinTaxIp);
                responseMessageTobinTax = client.PutAsJsonAsync("api/TobinTax/buy", stock).GetAwaiter().GetResult();
            }

            if(responseMessageTobinTax.StatusCode == HttpStatusCode.OK)
            {
                responseMessageUserStocks = await client.PostAsJsonAsync("api/UserStocks", stock);

                _context.AvailableStocks.Remove(stock);
                await _context.SaveChangesAsync();

                return responseMessageUserStocks.StatusCode;
            }
            
            return HttpStatusCode.InternalServerError;
        }

        private bool StockExists(int id)
        {
            return _context.AvailableStocks.Any(e => e.Id == id);
        }
    }
}
