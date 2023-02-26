namespace Hue.GlobalTool.Extensions.CommandLine;

using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using System.Text.Json;
using Enums;
using Feature.Lights.Commands.GetLight;
using Feature.Lights.Commands.GetLightList;
using Feature.Lights.Commands.UpdateLight;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;
using Spectre.Console.Json;

public static class LightCommandExtensions
{
    private static Command BuildLightListCommand()
    {
        return new Command("list")
        {
            Description = "List lights",
            Handler = CommandHandler.Create<InvocationContext, IHost>(
                async (invocationContext, host) =>
                {
                    var mediator = host.Services.GetService<IMediator>()!;

                    var apiResponse = await mediator.Send(
                        new GetLightListQuery(),
                        invocationContext.GetCancellationToken());

                    // TODO: write to console
                })
        };
    }

    private static Command BuildLightShowCommand()
    {
        var idOption = new Option<string>("--id")
        {
            IsRequired = true
        };

        var lightShowCommand = new Command("show")
        {
            Description = "Show light properties",
            Handler = CommandHandler.Create<InvocationContext, IHost, GetLightQuery>(
                async (invocationContext, host, getLightQuery) =>
                {
                    var mediator = host.Services.GetService<IMediator>()!;

                    var apiResponse = await mediator.Send(
                        getLightQuery,
                        invocationContext.GetCancellationToken());

                    // TODO: write to console
                })
        };

        lightShowCommand.AddOption(idOption);

        return lightShowCommand;
    }

    private static Command BuildLightUpdateCommand()
    {
        var idOption = new Option<string>("--id")
        {
            IsRequired = true
        };

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

        var lightUpdateCommand = new Command("update")
        {
            Description = "Update light properties",
            Handler = CommandHandler.Create<InvocationContext, IHost, UpdateLightCommand>(
                async (invocationContext, host, updateLightCommand) =>
                {
                    var mediator = host.Services.GetService<IMediator>()!;

                    var apiResponse = await mediator.Send(
                        updateLightCommand,
                        invocationContext.GetCancellationToken());

                    // TODO: write to console
                })
        };

        lightUpdateCommand.AddOption(idOption);
        lightUpdateCommand.AddOption(onOption);
        lightUpdateCommand.AddOption(brightnessOption);
        lightUpdateCommand.AddOption(colorTemperatureOption);

        return lightUpdateCommand;
    }

    public static RootCommand AddLightCommand(this RootCommand rootCommand)
    {
        var lightCommand = new Command("light");

        lightCommand.AddGlobalOption(new Option<Output>("--output", () => Output.Json)
        {
            IsRequired = false
        });

        lightCommand.AddCommand(BuildLightListCommand());
        lightCommand.AddCommand(BuildLightShowCommand());
        lightCommand.AddCommand(BuildLightUpdateCommand());

        // Register root command
        rootCommand.AddCommand(lightCommand);


        return rootCommand;
    }
}
