using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebelRentals.Models
{
    public class ShipOrder
    {
        [Key, Column(Order = 0)]
        public int ShipId { get; set; }
        public Ship Ship { get; set; }
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Count { get; set; }
    }
}