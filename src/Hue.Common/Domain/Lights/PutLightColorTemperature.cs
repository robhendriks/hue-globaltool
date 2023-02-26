namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class PutLightColorTemperature
{
    [JsonPropertyName("mirek")]
    public int? Mirek { get; set; }
}
