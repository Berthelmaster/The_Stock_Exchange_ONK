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
using System.Text;

namespace StockShareRequester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockShareRequesterController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string ip = "https://localhost:44336/";
        

        public StockShareRequesterController(AppDbContext context)
        {
            _context = context;
        }


        // PUT: api/StockShareRequester/5
        [HttpPut("{userId}")]
        public async Task<HttpStatusCode> BuyStock(int userId, Stock stock)
        {
            HttpResponseMessage response;

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(ip + "api/AvailableStocks/" + userId),
                Content = new StringContent(JsonConvert.SerializeObject(stock), Encoding.UTF8, "application/json")
            };

            response = await client.SendAsync(request);
            

            return response.StatusCode;
        }
    }
}
