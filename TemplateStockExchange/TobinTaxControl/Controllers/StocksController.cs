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
    public class StocksController : ControllerBase
    {
        private readonly AppDbContext _context;
        static HttpClient client = new HttpClient();
        private readonly string ip = "https://localhost:44341/";

        public StocksController(AppDbContext context)
        {
            _context = context;
        }

        // Used for BuyStock feature
        // PUT: api/Stocks/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutStock(int id, Stock stock)
        {
            HttpResponseMessage response;

            Transaction transaction = new Transaction(stock, stock.Price, stock.Price * 0.01);

            var newStockPrice = stock.Price * 0.99;

            stock.Price = newStockPrice;

            using ( client )
            {
                client.BaseAddress = new Uri(ip);
                response = await client.PostAsJsonAsync("api/UserStocks", stock);
            }

            return response.StatusCode;
        }
    }
}
