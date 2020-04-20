﻿using RestClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals
{
    public class APIController
    {
        public async Task<bool> ContainsProfanity(string stringToCheck)
        {
            var client = new Client(new Uri("https://www.purgomalum.com/service/containsprofanity?text=" + stringToCheck));
            var response = await client.GetAsync<bool>();
            return response;
        }
    }
}