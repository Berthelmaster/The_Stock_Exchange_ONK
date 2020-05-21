using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobinTaxControl.Data;
using TobinTaxControl.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace TobinTaxControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobinTaxController : ControllerBase
    {
        private readonly AppDbContext _context;
        private string _buy = "Buy";
        private string _sell = "Sell";

        public TobinTaxController(AppDbContext context)
        {
            _context = context;
        }

        // Used for BuyStock feature
        // PUT: api/Stocks/5
        [Route("buy")]
        [HttpPost]
        public async Task<ActionResult> TaxBuyStock(Stock stock)
        {
            if(stock == null)
            {
                return BadRequest();
            }

            Transaction transaction = new Transaction(_buy ,stock.Id, stock.Price, stock.FullPrice - stock.Price);

            _context.Add(transaction);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("sell")]
        public async Task<ActionResult> TaxSellStock(Stock stock)
        {
            Transaction transaction = new Transaction(_sell ,stock.Id, stock.Price, stock.FullPrice - stock.Price);

            _context.Add(transaction);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
