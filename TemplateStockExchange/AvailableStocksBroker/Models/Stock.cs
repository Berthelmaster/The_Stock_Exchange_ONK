﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvailableStocksBroker.Models
{
    public class Stock
    {

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

        public Stock(int id, double price, double fullPrice, string name, int quantity, string seller, string buyer, DateTime timeStamp, int userId)
        {
            Id = id;
            Price = price;
            FullPrice = fullPrice;
            Name = name;
            Quantity = quantity;
            Seller = seller;
            Buyer = buyer;
            TimeStamp = timeStamp;
            UserId = userId;
        }

        public Stock()
        {

        }

        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public double FullPrice { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserId { get; set; }

    }
}
