using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace RebelRentals
{
    public class TestModel : PageModel
    {
        public double conversionRate { get; private set; }

        public bool showConverterCurrency;

        public APIController _aPIController { get; set; }
        public List<Currency> CurrencyList { get; set; }

        public TestModel(APIController aPIController)
        {
            _aPIController = aPIController;
        }
        public void OnGet()
        {
            
        }
        public PageResult OnPostConvertCurrency()
        {
            conversionRate = JsonConvert.DeserializeObject<double>(HttpContext.Session.GetString("SessionRate"));
            showConverterCurrency = true;
            return Page();
        }
       
    }
}