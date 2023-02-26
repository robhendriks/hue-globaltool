namespace Hue.GlobalTool.Extensions.DependencyInjection;

using Common;
using Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class HueExtensions
{
    public static IServiceCollection AddHue(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<HueApiClientOptions>(services
                => new HueApiClientOptions(
                    services.GetService<ILogger>()!,
                    new Uri("https://192.168.1.118"), // TODO: load from config?
                    TimeSpan.FromSeconds(5)))
            .AddSingleton<IHueApiClient, HueApiClient>()
            .AddSingleton<IHueLightService, HueLightService>();
    }
}
