namespace Hue.GlobalTool.Extensions.CommandLine;

using System.CommandLine;

public static class BridgeCommandExtensions
{
    public static RootCommand AddBridgeCommand(this RootCommand rootCommand)
    {
        var bridgeCommand = new Command("bridge");

        // Register root command
        rootCommand.AddCommand(bridgeCommand);

        return rootCommand;
    }
}
