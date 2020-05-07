using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RebelRentals
{
    public class APIController
    {
        private readonly CurrencyConverter _currencyConverter;
        public APIController()
        {
        }
        public async Task<bool> ContainsProfanity(string stringToCheck)
        {
            var client = new Client(new Uri("https://www.purgomalum.com/service/containsprofanity?text=" + stringToCheck));
            var response = await client.GetAsync<bool>();
            return response;
        }
        public async Task<string> ConvertCurrency(string fromCurrency, string toCurrency)
        {
            var client = new Client(new Uri($"https://free.currconv.com/api/v7/convert?q={fromCurrency}_{toCurrency}&compact=ultra&apiKey=d32dfcb72bf0f09defeb"));
            var response = await client.GetAsync<string>();
            return response.Body;
        }
        public async Task<List<Currency>> SetCurrencyList()
        {
            var currencyList = new List<Currency>();
            var client = new Client(new Uri("https://free.currconv.com/api/v7/currencies?apiKey=d32dfcb72bf0f09defeb"));
            var currencyModel =  await client.GetAsync<CurrencyModel>();
            foreach (var prop in currencyModel.Body.Results.GetType().GetProperties())
            {
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(currencyModel.Body.Results, null));
                var currency = (Currency)prop.GetValue(currencyModel.Body.Results, null);
                currencyList.Add(currency);
            }
            return currencyList;
        }
        public async Task<string> GetUsage()
        {
            var client = new Client(new Uri("https://free.currconv.com/others/usage?apiKey=d32dfcb72bf0f09defeb"));
            var response = await client.GetAsync<string>();
            return response;
        }
    }
}
