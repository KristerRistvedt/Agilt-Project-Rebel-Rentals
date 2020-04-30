using Microsoft.AspNetCore.Mvc;
using RebelRentals;
using RestClient.Net;
using RestClient.Net.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace RebelRentals
{
    public class APIController
    {
        public ApodModel Apod { get; set; }

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

        public async Task<string> TranslateToSith(string inputString)
        {
            try
            {
                var client = new Client(new Uri("https://api.funtranslations.com/translate/sith.json?text=" + inputString));
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
    }
}
