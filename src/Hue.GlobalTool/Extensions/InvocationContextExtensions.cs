namespace Hue.GlobalTool.Extensions;

using System.CommandLine.Invocation;
using Enums;

public static class InvocationContextExtensions
{
    public static Output GetOutputOptionValue(this InvocationContext invocationContext)
    {
        return invocationContext.ParseResult.GetValueForOption(CommandExtensions.OutputOption)
               ?? Output.Json;
    }
}
