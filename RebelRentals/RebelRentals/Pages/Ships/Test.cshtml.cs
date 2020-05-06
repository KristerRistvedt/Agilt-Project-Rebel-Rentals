using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RebelRentals
{
    public class TestModel : PageModel
    {
        public APIController _aPIController { get; set; }
        public CurrencyConverter _currencyConverter { get; set; }
        public List<Currency> CurrencyList { get; set; }
        public CurrencyModel CurrencyModel { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }

        public TestModel(APIController aPIController, CurrencyConverter currencyConverter)
        {
            _aPIController = aPIController;
            _currencyConverter = currencyConverter;
        }
        public void OnGet()
        {
            
        }
        public async Task OnPostList()
        {
            CurrencyList = await _aPIController.SetCurrencyList();
        }
    }
}