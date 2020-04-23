namespace RebelRentals.Models
{
    public class ShipOrder
    {
        public int ShipId { get; set; }
        public Ship Ship { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}