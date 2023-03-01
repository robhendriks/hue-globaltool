namespace Hue.Common.Domain;

using System.Text.Json.Serialization;

public class Metadata
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("archetype")]
    public string ArcheType { get; set; } = null!;
}
