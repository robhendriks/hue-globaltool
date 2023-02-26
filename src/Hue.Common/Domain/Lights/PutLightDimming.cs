namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class PutLightDimming
{
    [JsonPropertyName("brightness")]
    public int? Brightness { get; set; }
}
