namespace Hue.GlobalTool.Extensions.CommandLine;

using Hue.Common.Domain.Lights;
using Spectre.Console;

public static class LightExtensions
{
    public static Table ToTable(this IEnumerable<GetLight> lights)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("ID").LeftAligned());
        table.AddColumn(new TableColumn("Name").LeftAligned());
        table.AddColumn(new TableColumn("Type").LeftAligned());

        foreach (var light in lights)
        {
            table.AddRow(light.Id, light.Metadata.Name, light.Metadata.ArcheType);
        }

        return table;
    }

    public static Table ToTable(this GetLight light)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("ID").LeftAligned());
        table.AddColumn(new TableColumn("Name").LeftAligned());
        table.AddColumn(new TableColumn("Type").LeftAligned());

        table.AddRow(light.Id, light.Metadata.Name, light.Metadata.ArcheType);

        return table;
    }
}
