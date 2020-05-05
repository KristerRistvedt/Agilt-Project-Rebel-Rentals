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
    public class DeleteModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public DeleteModel(RebelRentals.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ship = await _context.Ship.FindAsync(id);

            if (Ship != null)
            {
                _context.Ship.Remove(Ship);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
