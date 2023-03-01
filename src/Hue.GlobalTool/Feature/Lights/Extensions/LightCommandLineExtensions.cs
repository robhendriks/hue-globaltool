namespace Hue.GlobalTool.Feature.Lights.Extensions;

using System.CommandLine;
using CommandLine.CQRS;
using Commands.GetLight;
using Commands.GetLightList;
using Commands.UpdateLight;
using Common.Domain;
using Common.Domain.Lights;
using GlobalTool.Extensions;

public static class LightCommandLineExtensions
{
    private static Command BuildLightListCommand()
    {
        return new Command("list")
        {
            Description = "List lights",
            Handler = MediatorCommandHandler.CreateReadHandler<GetLightListQuery, GetLight>()
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
            Handler = MediatorCommandHandler.CreateReadHandler<GetLightQuery, GetLight>()
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
            Handler = MediatorCommandHandler.CreateWriteHandler<UpdateLightCommand, ResourceIdentifier>()
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

        lightCommand.AddCommand(BuildLightListCommand());
        lightCommand.AddCommand(BuildLightShowCommand());
        lightCommand.AddCommand(BuildLightUpdateCommand());

        // Register root command
        rootCommand.AddCommand(lightCommand);

        return rootCommand;
    }
}
