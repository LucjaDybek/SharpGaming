
namespace IFlow.Testing.Utils.DataFactory
{
    public static class ApiAddresses
    {
        private static string BaseApiUrl => "http://affiliate-feed.petfre.sgp.bet/1/";
        public static string HealthDataApiUrl => BaseApiUrl + "health";
        public static string CountriesDataApiUrl => BaseApiUrl + "countries";
    }
}
