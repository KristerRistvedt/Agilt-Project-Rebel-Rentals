using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelRentals.API_Models
{
    public class ApodModel
    {
        public string ApodSite { get; set; }
        public string Copyright { get; set; }
        public string Music { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string MediaType { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
