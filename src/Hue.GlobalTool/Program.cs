namespace Hue.GlobalTool;

using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using Common.ApiClient;
using Common.ApiClient.Extensions;
using Common.Services.Extensions;
using Feature.Lights.Extensions;
using Hue.CommandLine.Rendering.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console;

public static class Program
{
    private static void DoRootCommand()
    {
        AnsiConsole.Write(
            new FigletText("Hue")
                .LeftJustified()
                .Color(Color.White));
    }

    private static CommandLineBuilder BuildCommandLine()
    {
        var rootCommand = new RootCommand("Hue app");

        rootCommand.SetHandler(_ => DoRootCommand());

        rootCommand
            .AddLightCommand();

        return new CommandLineBuilder(rootCommand);
    }

    public static Task<int> Main(string[] args) =>
        BuildCommandLine()
            .UseHost(
                _ => Host.CreateDefaultBuilder(),
                host =>
                {
                    // Configure services
                    host.ConfigureServices(services =>
                    {
                        // Configure logging
                        services.AddLogging(builder => builder.ClearProviders());

                        // Configure MediatR
                        services.AddMediatR(configuration =>
                        {
                            // Register services
                            configuration.RegisterServicesFromAssemblyContaining(typeof(Program));
                        });

                        // Configure Hue
                        services
                            .AddHueApiClient(_ =>
                                new HueApiClientOptions(new Uri("https://192.168.1.118"), TimeSpan.FromSeconds(5)))
                            .AddHueServices()
                            .AddHueCommandLineRendering();
                    });
                })
            .UseDefaults()
            .Build()
            .InvokeAsync(args);
}
