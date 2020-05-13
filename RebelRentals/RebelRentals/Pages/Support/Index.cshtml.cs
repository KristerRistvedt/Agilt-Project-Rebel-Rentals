using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Support
{
    public class IndexModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public IndexModel(RebelRentals.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ShipOrder> ShipOrder { get;set; }

        public async Task OnGetAsync()
        {
            ShipOrder = await _context.ShipOrder
                .Include(s => s.Order)
                .Include(s => s.Ship).ToListAsync();
        }
    }
}
