using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TobinTaxControl.Models;

namespace TobinTaxControl.Data
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
        public DbSet<Transaction> Transactions { get; set; }
    }
}
