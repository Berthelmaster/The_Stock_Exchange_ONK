using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockShareProvider.Models;

namespace StockShareProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockShareProvicerController : ControllerBase
    {
        private readonly string AvailableStocksIp = "https://localhost:44336/";

        // PUT: api/StockShareRequester/5
        [HttpPut("{userId}")]
        public async Task<HttpStatusCode> SellStock(int userId, Stock stock)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(AvailableStocksIp);
                response = await client.PostAsJsonAsync("api/AvailableStocks/" + userId, stock);
            }

            return response.StatusCode;
        }
    }
}
