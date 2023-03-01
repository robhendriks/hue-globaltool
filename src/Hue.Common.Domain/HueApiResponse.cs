namespace Hue.Common.Domain;

using System.Text.Json.Serialization;

public class HueApiResponse<TData>
{
    [JsonPropertyName("errors")]
    public IReadOnlyCollection<HueApiError> Errors { get; set; } = Array.Empty<HueApiError>();

    [JsonPropertyName("data")]
    public IReadOnlyCollection<TData> Data { get; set; } = Array.Empty<TData>();
}
