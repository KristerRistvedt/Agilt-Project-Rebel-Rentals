using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace RebelRentals
{
    public class GalacticTranslationModel
    {
        [JsonProperty("success")]
        public Success Success { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("contents")]
        public Contents Contents { get; set; }
    }

    public partial class Contents
    {
        [JsonProperty("translated")]
        public string Translated { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("translation")]
        public string Translation { get; set; }
    }

    public partial class Success
    {
        [JsonProperty("total")]
        public long Total { get; set; }
    }
    public partial class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

