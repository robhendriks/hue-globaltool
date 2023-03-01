namespace Hue.CommandLine.Rendering;

using Abstractions;
using Common.Domain;
using Spectre.Console;

public class HueResourceIdentifierRenderer : IHueResourceIdentifierRenderer
{
    public void Render<T>(IEnumerable<T> resourceIdentifiers) where T : ResourceIdentifier
    {
        foreach (var resourceIdentifier in resourceIdentifiers)
        {
            AnsiConsole.MarkupLine(
                "[green]{0}[/] [white]{1}[/]", 
                "[OK]".EscapeMarkup(),
                resourceIdentifier.Id.EscapeMarkup());
        }
    }
}
