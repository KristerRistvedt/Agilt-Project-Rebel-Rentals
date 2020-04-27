using RebelRentals;
using RestClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        internal Task<bool> PhoneNumberValidation(int phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
