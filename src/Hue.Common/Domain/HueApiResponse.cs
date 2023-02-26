namespace Hue.Common.Domain;

public class HueApiResponse<T>
{
    public IReadOnlyCollection<object> Errors { get; set; } = Array.Empty<object>();
    public IReadOnlyCollection<T> Data { get; set; } = Array.Empty<T>();
}
