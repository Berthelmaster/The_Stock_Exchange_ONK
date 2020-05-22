using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserController.Models;

namespace UserController.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder builder)
        {
            User flow_user = new User(1, "flow", "flow@mail.dk", "1234", 50);
            User ras_user = new User(2, "ras", "ras@mail.dk", "1234", 50);
            User thom_user = new User(3, "thom", "thom@mail.dk", "1234", 50);

            builder.Entity<User>()
                .HasData(
                flow_user,
                ras_user,
                thom_user
                );
        }
        public DbSet<User> Users { get; set; }
    }
}
