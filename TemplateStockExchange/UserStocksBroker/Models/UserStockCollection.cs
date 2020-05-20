using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserStocksBroker.Models
{
    public class UserStockCollection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public List<Stock> Stocks { get; set; }

        public UserStockCollection(int id)
        {
            Id = id;
        }
    }
}
