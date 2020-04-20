using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;
        public List<Ship> ShoppingCart { get; set; }

        public IndexModel(RebelRentals.Data.ApplicationDbContext context, List<Ship> shoppingCart)
        {
            _context = context;
            ShoppingCart = shoppingCart;
        }

        public async Task OnGetAsync()
        {
            ShoppingCart = await _context.Ship.ToListAsync();
        }
    }
}
