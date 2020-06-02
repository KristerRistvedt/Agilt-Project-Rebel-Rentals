using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals
{
    public class ChuckNorrisQuotesModel
    {
        public Uri icon_url { get; set; }
        public string id { get; set; }
        public string value { get; set; }
    }
}
