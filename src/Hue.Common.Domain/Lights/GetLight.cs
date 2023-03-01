namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class GetLight
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; } = null!;
}
