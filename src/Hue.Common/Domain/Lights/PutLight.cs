namespace Hue.Common.Domain.Lights;

using System.Text.Json.Serialization;

public class PutLight
{
    [JsonPropertyName("on")]
    public PutLightOn? On { get; set; }

    [JsonPropertyName("dimming")]
    public PutLightDimming? Dimming { get; set; }

    [JsonPropertyName("color_temperature")]
    public PutLightColorTemperature? ColorTemperature { get; set; }
}
