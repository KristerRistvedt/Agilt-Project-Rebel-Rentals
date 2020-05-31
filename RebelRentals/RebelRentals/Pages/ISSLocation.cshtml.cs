using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RebelRentals.API_Models;

namespace RebelRentals.Pages.Ships
{
    public class ISSLocationModel : PageModel
    {
        private APIController _apiController;
        public ISSLocationModel(APIController apiController)
        {
            _apiController = apiController;
        }

        public string currentLocation;
        public bool showImage = false;
        public string issImage = "https://cdn.pixabay.com/photo/2015/01/15/16/01/iss-600459_960_720.jpg";
        public string showIss;
        public async Task<IActionResult> OnPostISSLocation()
        {
            
            currentLocation = await _apiController.GetIssInformation();
            return Page();
        }
        public async Task<IActionResult> OnPostShowImage()
        {
            showImage = true;
            showIss = issImage;
            return Page();
        }
    }
}