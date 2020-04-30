using Microsoft.AspNetCore.Mvc;
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

        public void AddShipToCart(Ship ship)
        {
            shoppingCart.Add(ship);
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
