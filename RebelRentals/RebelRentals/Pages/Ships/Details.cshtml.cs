using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Ships
{
    public class DetailsModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public DetailsModel(RebelRentals.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Ship Ship { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ship = await _context.Ship.FirstOrDefaultAsync(m => m.Id == id);

            if (Ship == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
