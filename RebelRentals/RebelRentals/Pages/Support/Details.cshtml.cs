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
    public class DetailsModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public DetailsModel(RebelRentals.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ShipOrder ShipOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShipOrder = await _context.ShipOrder
                .Include(s => s.Order)
                .Include(s => s.Ship).FirstOrDefaultAsync(m => m.ShipId == id);

            if (ShipOrder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
