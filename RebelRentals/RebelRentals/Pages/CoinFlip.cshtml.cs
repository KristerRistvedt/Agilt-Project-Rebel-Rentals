using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RebelRentals.Pages
{
    public class CoinFlipModel : PageModel
    {
        private readonly APIController _apiController;

        public CoinFlipModel(APIController apiController)
        {
            _apiController = apiController;
        }

        public string Coin { get; private set; }

        public void OnGet()
        {
         
        }
        public async Task<PageResult> OnPostFlipCoin()
        {
            string response = await _apiController.FlipCoin();
            Coin = response.Substring(1, 5);
            return Page();
        }
    }
}