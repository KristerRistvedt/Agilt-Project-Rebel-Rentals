﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Ships
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
            return Page();
        }

        [BindProperty]
        public Ship Ship { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ship.Add(Ship);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
