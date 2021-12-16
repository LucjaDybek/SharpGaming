using Atata;
using FluentAssertions;
using Flurl.Http;
using IFlow.Testing.Utils.DataFactory;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace IFlow.Testing.Utils.Api
{
    public static class GamesApi
    {
        public static async Task<dynamic> GetHealthData()
        {
            return (await ApiAddresses.HealthDataApiUrl
                .GetJsonAsync());
        }

        public static async Task<dynamic> GetCountryData(string language)
        {
            return (await ApiAddresses.CountriesDataApiUrl
                .AllowAnyHttpStatus()
                .SetQueryParam("languageCode", language)
                .GetJsonAsync());
        }

        public static void AreListElementsEqual(List<int> responseCountries) 
        {
            for (int i = 0; i < responseCountries.Count; i++)
            {
                for (int j = responseCountries.Count - 1; j > 0; j--)
                {
                    if (i != j) responseCountries[i].Should().Equals(responseCountries[j]);
                }
            }
        }

        public static List<string> TableToList(Table table)
        {
            var list = new List<string>();
            foreach (var row in table.Rows)
            {
                list.Add(row[0]);
            }
            return list;
        }
    }
}
