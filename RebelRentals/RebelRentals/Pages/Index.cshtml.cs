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
        private readonly ILogger<IndexModel> _logger;
        private readonly CurrencyConverter _currencyConverter;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, CurrencyConverter currencyConverter)
        {
            _currencyConverter = currencyConverter;
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
            Id = "USD",
            CurrencyName = "United States Dollar",
            CurrencySymbol = "$"
        };

        public void OnGet()
        {
            var sessionName = new Byte[20];
            bool nameExists = HttpContext.Session.TryGetValue("SessionCurrency", out sessionName);
            if (!nameExists)
            {
                HttpContext.Session.SetString("SessionCurrency", JsonConvert.SerializeObject(StartCurrency));
            }
        }
        public RedirectToPageResult OnPostToTestPage()
        {
            return RedirectToPage("./Index");
        }
    }
}
