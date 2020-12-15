using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

namespace CountriesAPI
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var countries = await GetCountriesByCallingCode(31);
            Console.WriteLine(countries[0].Population);
        }

        private static async Task<List<Country>> GetCountriesByCallingCode(int callingCode)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://restcountries-v1.p.rapidapi.com/callingcode/"+callingCode.ToString()),
                Headers =
                {
                    { "x-rapidapi-key", "87df6da5f0mshdc4ff4d39ed1d44p1696f0jsn20e0c00600ed" },
                    { "x-rapidapi-host", "restcountries-v1.p.rapidapi.com" },
                },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStreamAsync();
            var countries = await JsonSerializer.DeserializeAsync<List<Country>>(body);

            return countries;
                
        }
    }
}
