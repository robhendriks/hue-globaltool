namespace Hue.Common.Domain;

using System.Text.Json.Serialization;

public class ResourceIdentifier
{
    [JsonPropertyName("rid")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("rtype")]
    public string Type { get; set; } = null!;
}
