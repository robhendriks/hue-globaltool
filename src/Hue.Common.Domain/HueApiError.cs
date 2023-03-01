namespace Hue.Common.Domain;

using System.Text.Json.Serialization;

public class HueApiError
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;
}
