using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals.API_Models
{
    public class IssLocationModel
    {
        public IssLocation Location { get; set; }

        public partial class IssLocation
        {
            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("iss_position")]
            public IssPosition IssPosition { get; set; }
        }

        public partial class IssPosition
        {
            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [JsonProperty("longitude")]
            public string Longitude { get; set; }
        }
    }
}
