using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals.API_Models
{
   public class IssLocationModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
   /* public class IssLocationModel
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("iss_position")]
        public ISSPosition ISSPosition { get; set; }
        
        [JsonProperty("people")]
        public Person[] People { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }
    }
    public partial class ISSPosition
    {

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
    public partial class Person
    {
        [JsonProperty("craft")]
        public string Craft { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }*/
//}
