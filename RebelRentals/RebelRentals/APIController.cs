using RestClient.Net;
using System;
using RestClient.Net.Abstractions;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using MailMessage = System.Net.Mail.MailMessage;
using System.Collections.Generic;
using RebelRentals.API_Models;

namespace RebelRentals
{
    public class APIController
    {
        public ApodModel Apod { get; set; }

        private readonly string supportEmail = "rebelrentalshelp@gmail.com";
        private readonly string supportEmailPassword = "jyxviqmqiakwljhr";
        private readonly string smtpServerAddress = "smtp.gmail.com";

        public async Task<bool> ContainsProfanity(string stringToCheck)
        {
            var client = new Client(new Uri("https://www.purgomalum.com/service/containsprofanity?text=" + stringToCheck));
            var response = await client.GetAsync<bool>();
            return response;
        }

        public async Task<bool> UpdateApod()
        {
            bool updated;
            if (Apod == null)
            {
                var client = new Client(new Uri("https://apodapi.herokuapp.com/api"));
                var response = await client.GetAsync<ApodModel>();
                Apod = response;
                updated = true;
            }
            else { updated = false; }
            return updated;
        }

        internal async Task<bool> PhoneNumberValidation(int phoneNumber)
        {
            var client = new Client(new Uri("http://apilayer.net/api/validate?access_key=f994bc4c2013d3cd24fd50b8c6d1a5e6&number=" + phoneNumber + "&country_code=SE"));
            PhoneNumberValidationModel response = await client.GetAsync<PhoneNumberValidationModel>();
            bool result = response.Valid;
            return result;
        }

        public async Task<ChuckNorrisQuotesModel> ChuckNorrisQuote()
        {
            var client = new Client(new Uri("https://api.chucknorris.io/jokes/random"));
            ChuckNorrisQuotesModel response = await client.GetAsync<ChuckNorrisQuotesModel>();

            return response;
        }

        public bool SendEmailToSupport(string name, string senderEmail, string message)
        {
            bool result;
            try
            {
                SmtpClient client = new SmtpClient(smtpServerAddress, 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(supportEmail, supportEmailPassword);
                MailMessage messageObject = new MailMessage();
                messageObject.To.Add(supportEmail);
                messageObject.From = new MailAddress(senderEmail);
                messageObject.Subject = $"Query by: {name} / {senderEmail}";
                messageObject.Body = message;
                client.Send(messageObject);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        public async Task<string> TranslateToGalacticLanguage(string inputString, string translationLanguage)
        {
            string url = "https://api.funtranslations.com/translate/sith.json?text=";
            try
            {
                if (translationLanguage == "Sith") { url = "https://api.funtranslations.com/translate/sith.json?text="; }
                else if (translationLanguage == "Gungan") { url = "https://api.funtranslations.com/translate/gungan.json?text="; }
                else if (translationLanguage == "Yoda") { url = "https://api.funtranslations.com/translate/yoda.json?text="; }
                
                var client = new Client(new Uri(url + inputString));
                GalacticTranslationModel response = await client.GetAsync<GalacticTranslationModel>();
                var translation = response.Contents.Translated;
                return translation;
                
            }
            catch (Exception e)
            {
                var exception = e as HttpStatusException;
                if (exception.Response.StatusCode == 429)
                {
                    return "Too many requests, try again later";
                }
                return e.Message;
            }
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

        public async Task<string> GetIssInformation()
        {
            var client = new Client(new Uri("http://api.open-notify.org/iss-now.json"));
            IssLocationModel response = await client.GetAsync<IssLocationModel>();
            var latitude = response.Location.IssPosition.Latitude;
            var longitude = response.Location.IssPosition.Longitude;
            return latitude + longitude;
        }
    }
}