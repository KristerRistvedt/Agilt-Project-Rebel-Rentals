using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public virtual IdentityUser User { get; set; }
        public ICollection<ShipOrder> ShipOrders { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
