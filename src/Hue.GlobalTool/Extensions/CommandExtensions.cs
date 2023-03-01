namespace Hue.GlobalTool.Extensions;

using System.CommandLine;
using Enums;

public static class CommandExtensions
{
    public static readonly Option<Output?> OutputOption = new(new[] {"o", "output"});

    public static void AddOutputOptions(this Command command)
    {
        command.AddOption(OutputOption);
    }
}
