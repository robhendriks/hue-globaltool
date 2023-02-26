namespace Hue.Common.Domain;

using System.Text.Json.Serialization;

public class HueApiResponse<TData>
{
    [JsonPropertyName("errors")]
    public IReadOnlyCollection<object> Errors { get; set; } = Array.Empty<object>();
    
    [JsonPropertyName("data")]
    public IReadOnlyCollection<TData> Data { get; set; } = Array.Empty<TData>();
}
