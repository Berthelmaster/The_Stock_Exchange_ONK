using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserStocksBroker.Models;

namespace UserStocksBroker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        private void SeedData(ModelBuilder builder)
        {

        }

        public DbSet<UserStocksBroker.Models.Stock> Stock { get; set; }

    }
}
