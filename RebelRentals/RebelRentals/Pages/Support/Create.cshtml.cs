using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Support
{
    public class CreateModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public CreateModel(RebelRentals.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
        ViewData["ShipId"] = new SelectList(_context.Ship, "Id", "Class");
            return Page();
        }

        [BindProperty]
        public ShipOrder ShipOrder { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShipOrder.Add(ShipOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
