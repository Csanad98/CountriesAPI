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
        private const string baseURI = "https://restcountries-v1.p.rapidapi.com/";
        private const string headerKeyString = "x-rapidapi-key";
        private const string headerKey = "87df6da5f0mshdc4ff4d39ed1d44p1696f0jsn20e0c00600ed";
        
        static async Task Main(string[] args)
        {
            var countries = await GetCountriesByCallingCode(1);
            foreach(Country c in countries){
                Console.WriteLine(c.ToString());
            } 
            
        }

        private static async Task<List<Country>> GetCountriesByCallingCode(int callingCode)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseURI+"/callingcode/"+callingCode.ToString())
            };
            request.Headers.Add(headerKeyString, headerKey);
            var response = await client.SendAsync(request);
            try {
                response.EnsureSuccessStatusCode();
            } catch (HttpRequestException e){
                Console.Write(e.ToString());
                System.Environment.Exit(1);
            }
            
            var body = await response.Content.ReadAsStreamAsync();
            var countries = await JsonSerializer.DeserializeAsync<List<Country>>(body);

            return countries;
                
        }
    }
}
