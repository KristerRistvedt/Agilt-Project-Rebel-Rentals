using RebelRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals
{
    public class ShoppingCart
    {
        private List<Ship> shoppingCart = new List<Ship>();

        public void AddShipToCart(Ship ship)
        {
            shoppingCart.Add(ship);
        }

        public void RemoveShipFromCart(Ship ship)
        {
            shoppingCart.Remove(ship);
        }
    }
}
