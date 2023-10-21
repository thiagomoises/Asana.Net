using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Asana.Net.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddAsanaApiClient(this IServiceCollection services, AsanaApiOptions options, Action<IServiceProvider, HttpClient>? settingsAction = null)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));

            return services.AddRefitClient<IAsanaApiClient>()
                .ConfigureHttpClient((sc, c) =>
                {
                    c.BaseAddress = new Uri("https://app.asana.com/api/1.0");
                    c.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.ApiKey}");

                    if (settingsAction != null)
                        settingsAction(sc, c);
                });
        }

        public static IHttpClientBuilder AddAsanaApiClient(this IServiceCollection services, Action<AsanaApiOptions> options, Action<IServiceProvider, HttpClient>? settingsAction = null)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));
            var opt = new AsanaApiOptions();
            options.Invoke(opt);

            return AddAsanaApiClient(services, opt, settingsAction);
        }


        public static IHttpClientBuilder AddAsanaApiClient(this IServiceCollection services, IConfiguration configuration, Action<IServiceProvider, HttpClient>? settingsAction = null)
        {
            AsanaApiOptions options = new AsanaApiOptions();
            configuration.GetSection(nameof(AsanaApiOptions)).Bind(options);

            return AddAsanaApiClient(services, options, settingsAction);
        }
    }
}