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
        [Key]
        public int Id { get; set; }
        public Stock Stock { get; set; }
        public double currentStockPrice { get; set; }
        public double amountSubtracted { get; set; }
    }
}
