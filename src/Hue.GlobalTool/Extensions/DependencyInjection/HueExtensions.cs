namespace Hue.GlobalTool.Extensions.DependencyInjection;

using Common;
using Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;

public static class HueExtensions
{
    public static IServiceCollection AddHue(this IServiceCollection serviceCollection)
    {

        return serviceCollection.AddSingleton<IHueLightService, HueLightService>();
    }
}
