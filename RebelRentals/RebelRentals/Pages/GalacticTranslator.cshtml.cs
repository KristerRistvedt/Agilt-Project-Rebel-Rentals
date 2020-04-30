using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RebelRentals.Pages
{
    public class GalacticTranslatorModel : PageModel
    {
        private APIController _apiController;
        public GalacticTranslatorModel(APIController apiController)
        {
            _apiController = apiController;
        }
        [BindProperty]
        public string TextToTranslate { get; set; }
        public string TranslatedText;
        /*public void OnGet()
        {
            
        }*/
        public async Task<IActionResult> OnPostTranslation()
        {
            TranslatedText = await _apiController.TranslateToSith(TextToTranslate);
            return Page();
        }
    }
}