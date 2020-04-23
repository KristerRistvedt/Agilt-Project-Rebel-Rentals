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

        public List<Ship> GetShoppingList()
        {
            return shoppingCart;
        }

        public bool AddShipToCart(Ship ship)
        {
            bool success;
            if (shoppingCart.Any(element => element.Id == ship.Id)) 
            { 
                success = false;
            }
            else
            {
                shoppingCart.Add(ship);
                success = true;
            }
            return success;
        }

        public void RemoveShipFromCart(Ship ship)
        {
            shoppingCart.Remove(ship);
        }

        public void ClearCart()
        {
            shoppingCart.Clear();
        }
    }
}
