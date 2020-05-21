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
        [HttpGet]
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

        //// PUT: api/Users/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{userId}")]
        //[Route("sell")]
        //public async Task<HttpStatusCode> SoldStock(int userId, Stock stock)
        //{
        //    if (userId != stock.UserId)
        //    {
        //        return HttpStatusCode.BadRequest;
        //    }

        //    User user = _context.Users.Where(u => u.Id == userId).First();

        //    user.Stocks.Remove(stock);
        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (user == null)
        //        {
        //            return HttpStatusCode.NotFound;
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return HttpStatusCode.OK;
        //}

        //// PUT: api/Users/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{userId}")]
        //[Route("buy")]
        //public async Task<HttpStatusCode> BoughtStock(int userId, Stock stock)
        //{
        //    if (userId != stock.UserId)
        //    {
        //        return HttpStatusCode.BadRequest;
        //    }

        //    User user = _context.Users.Where(u => u.Id == userId).First();

        //    stock.User = user;

        //    user.Stocks.Add(stock);
        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (user == null)
        //        {
        //            return HttpStatusCode.NotFound;
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return HttpStatusCode.OK;
        //}

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
