namespace Hue.GlobalTool;

using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using Extensions.CommandLine;
using Extensions.DependencyInjection;
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
            .AddBridgeCommand()
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
                        services.AddHue();
                    });
                })
            .UseDefaults()
            .Build()
            .InvokeAsync(args);
}
