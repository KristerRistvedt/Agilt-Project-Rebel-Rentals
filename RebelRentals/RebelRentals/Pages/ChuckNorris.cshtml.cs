using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace RebelRentals.Pages
{
    public class ChuckNorrisModel : PageModel
    {
        public ChuckNorrisModel(APIController apiController)
        {
            ApiController = apiController;
            Message = "If you're sad and need a Chuck Norris quote to cheer you up, click this button:";
            IconURL = "https://upload.wikimedia.org/wikipedia/commons/3/30/Chuck_Norris_May_2015.jpg";
        }

        public APIController ApiController { get; set; }
        public ChuckNorrisQuotesModel chuckNorrisQuotesModel { get; set; }
        public string IconURL { get; set; }
        public bool FetchedAPI { get; set; } = false;

        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
            
        }

        public async void OnPostGetQuote()
        {
            chuckNorrisQuotesModel = ApiController.ChuckNorrisQuote().Result;
            FetchedAPI = true;
        }
    }
}