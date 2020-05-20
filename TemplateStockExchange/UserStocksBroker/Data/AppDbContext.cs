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
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder builder)
        {
            Stock stock1 = new Stock(1, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 1);
            Stock stock2 = new Stock(2, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 1);
            Stock stock3 = new Stock(3, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 1);
            Stock stock4 = new Stock(4, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 2);
            Stock stock5 = new Stock(5, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 2);
            Stock stock6 = new Stock(6, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 2);
            Stock stock7 = new Stock(7, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 3);
            Stock stock8 = new Stock(8, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 3);
            Stock stock9 = new Stock(9, 1, 1.1, "flow", 1, "seller", "buyer", DateTime.Now, 3);

            builder.Entity<Stock>()
                .HasData(
                    stock1,
                    stock2,
                    stock3,
                    stock4,
                    stock5,
                    stock6,
                    stock7,
                    stock8,
                    stock9
                );
        }

        public DbSet<Stock> Stock { get; set; }

    }
}
