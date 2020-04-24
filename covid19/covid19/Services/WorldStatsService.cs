using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using covid19.Interfaces;
using covid19.Models;
using Newtonsoft.Json;

namespace covid19.Services
{
    public class WorldStatsService : IWorldStatsService
    {
        public WorldModel Items { get; set; }
        public IEnumerable<CountryModel> CountryItems { get; set; }
        HttpClient client;

        public WorldStatsService()
        {
            client = new HttpClient();
        }

        public async Task<WorldModel> GetWorldAsync()
        {
            try
            {
                var url = "https://corona.lmao.ninja/v2/all";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<WorldModel>(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }

        public async Task<IEnumerable<CountryModel>> GetByCountryListAsync()
        {
            try
            {
                var url = "https://corona.lmao.ninja/v2/countries";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    CountryItems = JsonConvert.DeserializeObject<IEnumerable<CountryModel>>(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return CountryItems;
        }

    }
}
