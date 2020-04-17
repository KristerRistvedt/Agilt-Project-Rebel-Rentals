using RebelRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals
{
    public class ShoppingCart
    {
        private List<Ship> shoppingCart = new List<Ship>
        {
            new Ship
            {
                Model = "A-Wing",
                Class = "Very Fighter",
                Height = 1,
                Length = 1,
                Width = 1,
                Price = 100,
                NumberOfPopulation = 1,
                MaxSpeed = 1000
            },
            new Ship
            {
                Model = "X-Wing",
                Class = "Very Fighter",
                Height = 1,
                Length = 1,
                Width = 1,
                Price = 100,
                NumberOfPopulation = 1,
                MaxSpeed = 1000
            }
        };
        public List<Ship> GetShoppingList()
        {
            return shoppingCart;
        }

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
