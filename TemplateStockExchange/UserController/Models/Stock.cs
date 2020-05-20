using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserController.Models
{
    public class Stock
    {

        public Stock(int id, int price, string name, int quantity, string seller, string buyer, DateTime timeStamp, User user)
        {
            Id = id;
            Price = price;
            Name = name;
            Quantity = quantity;
            Seller = seller;
            Buyer = buyer;
            TimeStamp = timeStamp;
            User = user;
        }

        public Stock(int id, int price, string name, int quantity, string seller, string buyer, DateTime timeStamp)
        {
            Id = id;
            Price = price;
            Name = name;
            Quantity = quantity;
            Seller = seller;
            Buyer = buyer;
            TimeStamp = timeStamp;
        }

        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public DateTime TimeStamp { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
