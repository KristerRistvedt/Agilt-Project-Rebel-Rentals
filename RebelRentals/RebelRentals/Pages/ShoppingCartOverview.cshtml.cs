using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages
{
    public class ShoppingCartOverviewModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartOverviewModel(RebelRentals.Data.ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public IList<Ship> Ship { get;set; }
       
        public async Task OnGetAsync()
        {
            Ship = _shoppingCart.GetShoppingList().ToList();
        }
    }
}
