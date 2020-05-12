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
    public class ChuckNorrisQuotesModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "If you're sad and need a Chuck Norris quote to cheer you up, click this button:";
        }

        public void OnPostGetQuote()
        {
             
        }
    }
}