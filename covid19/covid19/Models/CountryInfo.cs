using System;
using Newtonsoft.Json;

namespace covid19.Models
{
    public class CountryInfo
    {
        public int? _id { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "long")]
        public double Longitude { get; set; }

        public string flag { get; set; }
    }
}