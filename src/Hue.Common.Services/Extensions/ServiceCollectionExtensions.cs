namespace Hue.Common.Services.Extensions;

using Abstractions;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHueServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<IHueLightService, HueLightService>();
    }
}
