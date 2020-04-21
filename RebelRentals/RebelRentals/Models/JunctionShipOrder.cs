using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals.Models
{
    public class JunctionShipOrder
    {
        public int Id { get; set; }
        public List<int> ShipId { get; set; }
        public string CustomerId { get; set; }
    }
}
