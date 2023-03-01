namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class GetRoom : Resource
{
    [JsonPropertyName("children")]
    public IEnumerable<ResourceIdentifier> Children { get; set; } = Enumerable.Empty<ResourceIdentifier>();

    [JsonPropertyName("services")]
    public IEnumerable<ResourceIdentifier> Services { get; set; } = Enumerable.Empty<ResourceIdentifier>();
}
