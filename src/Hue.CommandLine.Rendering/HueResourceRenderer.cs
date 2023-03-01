namespace Hue.CommandLine.Rendering;

using Abstractions;
using Common.Domain;
using Spectre.Console;

public class HueResourceRenderer : IHueResourceRenderer
{
    public void Render<T>(IEnumerable<T> resources) where T : Resource
    {
        var table = new Table();

        table.AddColumn("ID")
            .AddColumn("Name")
            .AddColumn("Type");

        foreach (var resource in resources)
        {
            table.AddRow(resource.Id, resource.Metadata.Name, resource.Type);
        }

        AnsiConsole.Write(table);
    }
}
