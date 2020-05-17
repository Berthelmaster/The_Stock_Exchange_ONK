using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AvailableStocksBroker.Models;

namespace AvailableStocksBroker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

        private void SeedData(ModelBuilder builder)
        {
            
        }

        public DbSet<Stock> AvailableStocks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
