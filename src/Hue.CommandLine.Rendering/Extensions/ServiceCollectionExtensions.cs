namespace Hue.CommandLine.Rendering.Extensions;

using Abstractions;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHueCommandLineRendering(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IHueApiErrorRenderer, HueApiErrorRenderer>()
            .AddSingleton<IHueResourceIdentifierRenderer, HueResourceIdentifierRenderer>()
            .AddSingleton<IHueResourceRenderer, HueResourceRenderer>();
    }
}
