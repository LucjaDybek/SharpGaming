using Flurl.Http;
using IFlow.Testing.Utils.DataFactory;
using System.Threading.Tasks;

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
    }
}
