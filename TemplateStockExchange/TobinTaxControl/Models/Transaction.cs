using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TobinTaxControl.Models
{
    public class Transaction
    {
        public Transaction(string state, int stockId, double currentStockPrice, double amountSubtracted)
        {
            State = state;
            StockId = stockId;
            CurrentStockPrice = currentStockPrice;
            AmountSubtracted = amountSubtracted;
        }

        [Key]
        public int Id { get; set; }
        public string State { get; set; }
        public int StockId { get; set; }
        public double CurrentStockPrice { get; set; }
        public double AmountSubtracted { get; set; }
    }
}
