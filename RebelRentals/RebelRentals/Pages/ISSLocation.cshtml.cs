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
       
        public async Task<IActionResult> OnPostISSLocation()
        {
            
            currentLocation = await _apiController.GetIssInformation(); //await _apiController.GetPeopleInSpace();
            return Page();
        }
    }
}