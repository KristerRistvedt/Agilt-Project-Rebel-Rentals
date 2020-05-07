using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals
{
    public class CurrencyConverter
    {
        public List<Currency> CurrencyList { get; private set; }
        public readonly APIController _aPIController;
        public CurrencyConverter(APIController aPIController)
        {
            _aPIController = aPIController;
        }
        

    }
}
