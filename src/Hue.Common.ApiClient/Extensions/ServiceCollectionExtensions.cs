namespace Hue.Common.ApiClient.Extensions;

using Abstractions;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHueApiClient(this IServiceCollection serviceCollection,
        Func<IServiceProvider, HueApiClientOptions> optionsFactory)
    {
        return serviceCollection
            .AddSingleton(optionsFactory)
            .AddSingleton<IHueApiClient, HueApiClient>();
    }
}
