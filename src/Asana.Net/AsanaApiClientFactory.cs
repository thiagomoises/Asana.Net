using Refit;

namespace Asana.Net
{
    public static class AsanaApiClientFactory
    {
        public static IAsanaApiClient Create(string apiToken)
        {
            var configuredHttpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://app.asana.com/api/1.0")
            };

            configuredHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
            return RestService.For<IAsanaApiClient>(configuredHttpClient);
        }
    }
}
