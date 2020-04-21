using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals.Models
{
    public class Order
    {
        public Order(DateTime purchaseDate)
        {
            DateOfPurchase = purchaseDate;
        }
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
