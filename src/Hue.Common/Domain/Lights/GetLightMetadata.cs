namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class GetLightMetadata
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("archetype")]
    public string ArcheType { get; set; } = null!;
}
