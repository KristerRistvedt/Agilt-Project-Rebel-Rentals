using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Support
{
    [Authorize(Roles = "Support")]
    public class DeleteModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public DeleteModel(RebelRentals.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShipOrder ShipOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int shipId, int orderId)
        {
            if (shipId == 0 || orderId == 0)
            {
                return NotFound();
            }

            ShipOrder = await _context.ShipOrder
                .Include(s => s.Order)
                .Include(s => s.Ship).FirstOrDefaultAsync(m => m.ShipId == shipId);

            if (ShipOrder == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int shipId, int orderId)
        {
            if (shipId == 0 || orderId == 0)
            {
                return NotFound();
            }

            ShipOrder = await _context.ShipOrder.FindAsync(shipId, orderId);

            if (ShipOrder != null)
            {
                _context.ShipOrder.Remove(ShipOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
