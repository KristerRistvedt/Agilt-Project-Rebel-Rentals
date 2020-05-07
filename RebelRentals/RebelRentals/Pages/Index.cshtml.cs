using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RebelRentals.Data;
using RebelRentals.Models;
using RebelRentals.Pages.Ships;

namespace RebelRentals.Pages
{
    public class IndexModel : PageModel
    {
      private readonly ILogger<IndexModel> _logger;
      public APIController apiController;
      public ApodModel Apod { get; set; }
      public ApplicationDbContext _context { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, APIController apiController)
        {
          _logger = logger;
          this.apiController = apiController;
          var task = Task.Run(async () => { await UpdateApod(); });
          task.Wait();
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

        public Currency StartCurrency = new Currency()
        {
            Id = "SEK",
            CurrencyName = "Swedish Krona",
            CurrencySymbol = "kr"
        };

        public void OnGetAsync()
        {
            var sessionName = new Byte[20];
            bool currencyExists = HttpContext.Session.TryGetValue("SessionCurrency", out sessionName);
            if (!currencyExists)
            {
                HttpContext.Session.SetString("SessionCurrency", JsonConvert.SerializeObject(StartCurrency));
            }
            bool rateExists = HttpContext.Session.TryGetValue("SessionRate", out sessionName);
            if (!rateExists)
            {
                HttpContext.Session.SetString("SessionRate", JsonConvert.ToString(1));
            }
        } 
        public async Task<bool> UpdateApod()
        {
          bool updated = await apiController.UpdateApod();
          Apod = apiController.Apod;
          return updated;
        }

    }
}
