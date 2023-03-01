namespace Hue.CommandLine.Rendering;

using Abstractions;
using Common.Domain;
using Spectre.Console;

public class HueApiErrorRenderer : IHueApiErrorRenderer
{
    public void Render(IEnumerable<HueApiError> apiErrors)
    {
        foreach (var hueApiError in apiErrors)
        {
            AnsiConsole.MarkupLine(
                "[red]{0}[/] {1}",
                "[FAIL]".EscapeMarkup(),
                hueApiError.Description.EscapeMarkup());
        }
    }
}
