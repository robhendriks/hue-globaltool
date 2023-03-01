namespace Hue.CommandLine.Rendering.Abstractions;

using Common.Domain;

public interface IHueApiErrorRenderer
{
    void Render(IEnumerable<HueApiError> apiErrors);
}
