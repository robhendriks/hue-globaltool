namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class PutLightOn
{
    [JsonPropertyName("on")]
    public bool? On { get; set; }
}
