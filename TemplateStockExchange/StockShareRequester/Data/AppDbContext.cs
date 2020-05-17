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

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Stocks)
            //    .WithOne(s => s.User)
            //    .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.User)
                .WithMany(u => u.Stocks)
                .HasForeignKey(s => s.UserId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder builder)
        {
            Stock stock1 = new Stock(1, 1, "Vestas", 3, "ras", "flow", DateTime.Now);
            Stock stock2 = new Stock(2, 11, "Novo", 5, "thom", "flow", DateTime.Now);
            Stock stock3 = new Stock(3, 111, "Maersk", 10, "ras", "flow", DateTime.Now);
            Stock stock4 = new Stock(4, 1, "Marcus", 7, "flow", "ras", DateTime.Now);
            Stock stock5 = new Stock(5, 11, "Aarhus University", 12, "thom", "ras", DateTime.Now);
            Stock stock6 = new Stock(6, 111, "Shit", 10, "thom", "ras", DateTime.Now);
            Stock stock7 = new Stock(7, 1, "LOL", 10, "flow", "thom", DateTime.Now);
            Stock stock8 = new Stock(8, 11, "Testing", 20, "ras", "thom", DateTime.Now);
            Stock stock9 = new Stock(9, 111, "Systematic", 25, "ras", "thom", DateTime.Now);

            User flow_user = new User(1, "Florent", "something@gmail.com", "123456");
            User ras_user = new User(2, "Thomas", "thom@gmail.com", "123456");
            User thom_user = new User(3, "Rasmus", "ras@gmail.com", "123456");

            stock1.UserId = flow_user.Id;
            stock2.UserId = flow_user.Id;
            stock3.UserId = flow_user.Id;

            stock4.UserId = ras_user.Id;
            stock5.UserId = ras_user.Id;
            stock6.UserId = ras_user.Id;

            stock7.UserId = thom_user.Id;
            stock8.UserId = thom_user.Id;
            stock9.UserId = thom_user.Id;


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

            builder.Entity<User>()
                .HasData(
                    flow_user,
                    ras_user,
                    thom_user
                );

            //builder.Entity<User>(u =>
            //{
            //    u.HasData(
            //        flow_user
            //    );
            //    u.OwnsMany(s => s.Stocks)
            //        .HasData(

            //            stocksForFlorent

            //        );
            //}
            //);
                


        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
