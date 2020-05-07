using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Ships
{
    public class IndexModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;
        ShoppingCart _shoppingCart;

        public IndexModel(RebelRentals.Data.ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public IList<Ship> Ship { get;set; }

        public void OnGetAsync()
        {
            //_context.SeedShipData();
            Ship = _context.Ship.ToList();
        }

        public async Task<IActionResult> OnPostAddToShoppingCart(int id)
        {
            Ship shipToAdd = _context.Ship.First(ship => ship.Id == id);
            if (shipToAdd != null) { _shoppingCart.AddShipToCart(shipToAdd); }
            return RedirectToPage();
        }
    }
}
