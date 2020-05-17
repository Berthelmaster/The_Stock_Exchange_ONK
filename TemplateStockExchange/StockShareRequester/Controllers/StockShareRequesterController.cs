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


        // PUT: api/StockShareRequester/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> BuyStock(int id, Stock stock)
        {
            HttpResponseMessage response;

            using (client)
            {
                client.BaseAddress = new Uri(ip);
                response = await client.PostAsJsonAsync("api/AvailableStocks", stock);
            }

            return response.StatusCode;
        }
    }
}
