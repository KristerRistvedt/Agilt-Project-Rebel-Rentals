using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;
using SQLitePCL;

namespace RebelRentals.Pages.OrderPage
{
    public class SummaryModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public SummaryModel(RebelRentals.Data.ApplicationDbContext context, List<ShipOrder> summaryShipOrders, ShoppingCart shoppingCart)
        {
            _context = context;
            ShoppingCart = shoppingCart;
            ShipOrders = summaryShipOrders;
        }

        public Order Order { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<ShipOrder> ShipOrders { get; set; }
        public List<Ship> RentedShips 
        {  
            get
            {
                return RentedShips;
            }

            set
            {
                RentedShips = ShoppingCart.GetShoppingList();
            }
        }
        public int NumberOfShipsRented 
        {  
            get
            {
                return NumberOfShipsRented;
            }

            set
            {
                NumberOfShipsRented = ShipOrders.Count();
            }
        }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    Order = await _context.Order.FirstOrDefaultAsync(m => m.Id == id);
        //
        //    if (Order == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}
    }
}
