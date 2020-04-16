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
    public class IndexModel : PageModel
    {
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public IndexModel(RebelRentals.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Ship> Ship { get;set; }

        public async Task OnGetAsync()
        {
            Ship = await _context.Ship.ToListAsync();
        }
    }
}
