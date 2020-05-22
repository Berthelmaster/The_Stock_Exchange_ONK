using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserController.Data;
using UserController.Models;
using UserController.DTO;
using System.Net.Http;
using Newtonsoft.Json;

namespace UserController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // Used for Authentication Login - No Encryption
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<User>> Login(LoginDto logindetails)
        {
            var findUser = await _context.Users.Where(u => u.Email == logindetails.Email && u.Password == logindetails.Password).FirstOrDefaultAsync();

            if (findUser != null)
                return Ok(findUser);

            return BadRequest();

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> ChangeBalances(int userId, Stock stock)
        {
            var buyer = await _context.Users.Where(a => a.Id == userId).FirstOrDefaultAsync();
            var seller = await _context.Users.Where(u => u.Id == stock.UserId).FirstOrDefaultAsync();

            buyer.Balance -= stock.FullPrice;
            seller.Balance += stock.FullPrice;

            _context.Entry(buyer).State = EntityState.Modified;
            _context.Entry(seller).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
