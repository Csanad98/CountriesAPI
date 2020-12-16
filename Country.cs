using System;
using System.Text.Json.Serialization;

namespace CountriesAPI
{
    public class Country
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("capital")]
        public string Capital { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }

        public override string ToString()
        {
            return "Country: " + Name + ", Capital: " + Capital + ", Region: " + Region + ", Population: " + Population;
        }
    }
}
