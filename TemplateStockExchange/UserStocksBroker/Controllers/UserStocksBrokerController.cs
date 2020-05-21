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

        public UserStocksBrokerController(AppDbContext context)
        {
            _context = context;
        }       

        // Used for when you want to post a stock to the USB database, when a stock is bought
        [HttpPost("{userId}")]
        public async Task<ActionResult> BuyStock(int userId, Stock stock)
        {
            //Maybe add stuff to User also?

            Stock newStock = new Stock(stock.Id, stock.Price, stock.FullPrice, stock.Name, stock.Quantity, stock.Seller, stock.Buyer, stock.TimeStamp, userId);

            _context.Stock.Add(newStock);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // Used for when you want to sell a stock and therefore delete it for your portfolio
        [HttpDelete("{userId}")]
        public async Task<ActionResult> SellStock(int userId, Stock stock)
        {
            var query = await _context.Stock.Where(s => s.Id == stock.Id).FirstOrDefaultAsync();

            if(query != null)
            {
                _context.Stock.Remove(query);
            }
            else
            {
                Console.WriteLine("Error, no stock found");
            }


            return Ok();            
        }
    }
}
