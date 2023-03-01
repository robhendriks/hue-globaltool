namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class GetRoom
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("children")]
    public IEnumerable<ResourceIdentifier> Children { get; set; } = Enumerable.Empty<ResourceIdentifier>();

    [JsonPropertyName("services")]
    public IEnumerable<ResourceIdentifier> Services { get; set; } = Enumerable.Empty<ResourceIdentifier>();

    public Metadata Metadata { get; set; } = null!;
}
