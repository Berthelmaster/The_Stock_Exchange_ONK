using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace UserStocksBroker.Models
{
    public class Stock
    {
        public Stock(int id, double price, double fullPrice, string name, int quantity, DateTime timeStamp, int userId)
        {
            Id = id;
            Price = price;
            FullPrice = fullPrice;
            Name = name;
            Quantity = quantity;
            UserId = userId;
            TimeStamp = timeStamp;
        }

        public Stock()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public double Price { get; set; }
        public double FullPrice { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeStamp { get; set; }
        public UserStockCollection UserStockCollection{ get; set; }
        public int UserId { get; set; }
    }
}
