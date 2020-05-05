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
        [BindProperty]
        public string SelectedLanguage { get; set; }
        public string[] TranslationLanguages = new string[]
        {
            "Sith",
            "Gungan",
            "Yoda"
        };

        public async Task<IActionResult> OnPostTranslation()
        {
            TranslatedText = await _apiController.TranslateToGalacticLanguage(TextToTranslate, SelectedLanguage);
            return Page();
        }
    }
}