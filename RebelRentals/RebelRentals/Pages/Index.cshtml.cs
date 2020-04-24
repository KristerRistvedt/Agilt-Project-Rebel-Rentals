using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RebelRentals;
using RebelRentals.Data;

namespace RebelRentals.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public APIController apiController;
        public ApodModel Apod { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, APIController apiController)
        {
            _logger = logger;
            this.apiController = apiController;
            UpdateApod();

            if (context.Ship.Any())
            {
                return;
            }
            else
            {
                context.SeedShipData();
            }
        }

        public async void UpdateApod()
        {
            await apiController.UpdateApod();
            Apod = apiController.Apod;
        }
    }
}
