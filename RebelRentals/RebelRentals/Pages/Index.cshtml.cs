using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RebelRentals.Data;

namespace RebelRentals.Pages
{
    public class IndexModel : PageModel
    {
        private readonly APIController _aPIController;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, APIController aPIController)
        {
            _aPIController = aPIController;
            _logger = logger;

            if (context.Ship.Any())
            {
                return;
            }
            else
            {
                context.SeedShipData();
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
        public RedirectToPageResult OnPostToTestPage()
        {
            return RedirectToPage("./Test");
        }
    }
}
