﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RebelRentals.Data;
using RebelRentals.Models;
using SQLitePCL;

namespace RebelRentals.Pages.OrderPage
{
    public class SummaryModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public SummaryModel(RebelRentals.Data.ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            ShoppingCart = shoppingCart;
            ShipOrders = shoppingCart.OrderedShips;
        }

        public Order Order { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<ShipOrder> ShipOrders { get; set; }
        public List<ShipOrder> ShipOrdersCopy { get; set; }

        [BindProperty]
        public double TotalCost { get; set; }

        public void TotalOrderCost()
        {
            TotalCost = 0.0;

            foreach (var item in ShipOrdersCopy)
            {
                TotalCost = TotalCost + (item.Ship.Price * item.Count);
            }
        }

        public void EmptyCart()
        {
            ShoppingCart.ClearCart();
        }

        public void OnGetAsync()
        {
            ShipOrdersCopy = new List<ShipOrder>();
            foreach (var item in ShipOrders)
            {
                ShipOrdersCopy.Add(item);
            }
            TotalOrderCost();
            EmptyCart();
            ShoppingCart.ClearShipOrders();
        }
    }
}
