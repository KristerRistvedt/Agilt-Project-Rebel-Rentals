using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RebelRentals.Data;
using RebelRentals.Models;
using RebelRentals.Pages.Ships;

namespace RebelRentals.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ApplicationDbContext _context { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

            if (_context.Ship.Any())
            {
                return;
            }
            else
            {
                _context.SeedShipData();
            }
        }

        public void OnGet()
        {
            
        }

        /*public void AvailableShips()
        {
            (new Ship
            {
                Model = "A-Wing",
                NumberOfPopulation = 1,
                Class = "Interception starfighter",
                MaxSpeed = 1300,
                Length = 7,
                Width = 4,
                Height = 2,
                Price = 600,
                About = "They are the fastest vessels in the Star Wars canon.",
            });
            Ship.Add(new Ship
            {
                Model = "Death Star",
                NumberOfPopulation = 250000,
                Class = "Space Battle Station",
                MaxSpeed = 1000000,
                Length = 120,
                Width = 120,
                Height = 120,
                Price = 5000,
                About = "Faster than light speed.",
            });
            Ship.Add(new Ship
            {
                Model = "Salvation",
                NumberOfPopulation = 834,
                Class = "Frigate",
                MaxSpeed = 800,
                Length = 300,
                Width = 72,
                Height = 166,
                Price = 2000,
                About = "Generally well-armed for a vessel of that size.",
            });
            Ship.Add(new Ship
            {
                Model = "Star Destroyer",
                NumberOfPopulation = 10000,
                Class = "Star Destroyer",
                MaxSpeed = 975,
                Length = 1600,
                Width = 600,
                Height = 500,
                Price = 3500,
                About = "The signature vessel of the fleet.",
            });
            Ship.Add(new Ship
            {
                Model = "Tie Fighter",
                NumberOfPopulation = 1,
                Class = "Space superiority fighter",
                MaxSpeed = 1200,
                Length = 7,
                Width = 6,
                Height = 9,
                Price = 300,
                About = "They are fast, agile, yet fragile starfighters.",
            });
            Ship.Add(new Ship
            {
                Model = "X-Wing",
                NumberOfPopulation = 1,
                Class = "Space superiority fighter",
                MaxSpeed = 1050,
                Length = 13,
                Width = 11,
                Height = 2,
                Price = 400,
                About = "Named for the distinctive shape made when its wings are in attack position.",
            });
            Ship.Add(new Ship
            {
                Model = "Y-Wing",
                NumberOfPopulation = 1,
                Class = "	Assault starfighter/bomber",
                MaxSpeed = 1000,
                Length = 23,
                Width = 8,
                Height = 2,
                Price = 350,
                About = "Prized for its durability and long-range striking capability.",
            });
        }*/
    }
}
