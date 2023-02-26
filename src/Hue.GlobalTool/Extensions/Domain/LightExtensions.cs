namespace Hue.GlobalTool.Extensions.Domain;

using Common.Domain.Lights;
using Spectre.Console;

public static class LightExtensions
{
    public static Table ToTable(this GetLight getLight)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("ID").Centered());
        table.AddColumn(new TableColumn("Name").Centered());
        table.AddColumn(new TableColumn("Type").Centered());

        table.AddRow(getLight.Id, getLight.Metadata.Name, getLight.Metadata.ArcheType);

        return table;
    }
}
