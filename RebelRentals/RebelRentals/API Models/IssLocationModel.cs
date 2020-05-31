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