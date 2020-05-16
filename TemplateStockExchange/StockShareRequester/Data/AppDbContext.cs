using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockShareRequester.Models;

namespace StockShareRequester.Data
{
    public class AppDbContext :  DbContext
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

        public DbSet<StockShareRequester.Models.Stock> Stock { get; set; }
    }
}
