namespace Hue.GlobalTool.Extensions.CommandLine;

using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using System.Text.Json;
using Application.Lights.Commands.GetLight;
using Application.Lights.Commands.UpdateLight;
using Domain;
using Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

public static class LightCommandExtensions
{
    private static Command BuildLightGetCommand()
    {
        var lightGetCommand = new Command("get")
        {
            Description = "Get light properties",
            Handler = CommandHandler.Create<InvocationContext, IHost, GetLightQuery>(
                async (invocationContext, host, getLightQuery) =>
                {
                    var mediator = host.Services.GetService<IMediator>();

                    var apiResponse = await mediator!.Send(
                        getLightQuery,
                        invocationContext.GetCancellationToken());

                    var getLight = apiResponse?.Data.FirstOrDefault();
                    if (getLight != null)
                    {
                        if (getLightQuery.Output == Output.Table)
                        {
                            AnsiConsole.Write(getLight.ToTable());
                        }
                        else
                        {
                            Console.WriteLine(JsonSerializer.Serialize(getLight, new JsonSerializerOptions
                            {
                                WriteIndented = true
                            }));
                        }

                        return 0;
                    }

                    AnsiConsole.Write(new Markup("[red]Not found.[/]"));
                    return 1;
                })
        };

        return lightGetCommand;
    }

    private static Command BuildLightSetCommand()
    {
        var onOption = new Option<bool>("--on")
        {
            IsRequired = false
        };

        var brightnessOption = new Option<int>("--brightness")
        {
            IsRequired = false
        };

        brightnessOption.AddRangeValidator(0, 100);

        var colorTemperatureOption = new Option<int>(new[] {"--color-temperature", "--temp"})
        {
            IsRequired = false
        };

        colorTemperatureOption.AddRangeValidator(153, 500);

        var lightSetCommand = new Command("set")
        {
            Description = "Set light properties",
            Handler = CommandHandler.Create<InvocationContext, IHost, UpdateLightCommand>(
                async (invocationContext, host, updateLightCommand) =>
                {
                    var mediator = host.Services.GetService<IMediator>();

                    await mediator!.Send(
                        updateLightCommand,
                        invocationContext.GetCancellationToken());
                })
        };

        lightSetCommand.AddOption(onOption);
        lightSetCommand.AddOption(brightnessOption);
        lightSetCommand.AddOption(colorTemperatureOption);

        return lightSetCommand;
    }

    public static void AddLightCommand(this RootCommand rootCommand)
    {
        var lightCommand = new Command("light");

        lightCommand.AddGlobalOption(new Option<string>("--id")
        {
            IsRequired = true
        });

        lightCommand.AddGlobalOption(new Option<Output>("--output", () => Output.Json)
        {
            IsRequired = false
        });

        lightCommand.AddCommand(BuildLightGetCommand());
        lightCommand.AddCommand(BuildLightSetCommand());

        // Register root command
        rootCommand.AddCommand(lightCommand);
    }
}
