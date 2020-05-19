using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Support
{
    [Authorize(Roles = "Support")]
    public class EditModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public EditModel(RebelRentals.Data.ApplicationDbContext context)
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["ShipId"] = new SelectList(_context.Ship, "Id", "Class");
            ViewData["Count"] = new SelectList(_context.ShipOrder, "Count");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShipOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipOrderExists(ShipOrder.ShipId, ShipOrder.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShipOrderExists(int? shipId, int? orderId)
        {
            return _context.ShipOrder.Any(e => e.ShipId == shipId && e.OrderId == orderId);
        }
    }
}
