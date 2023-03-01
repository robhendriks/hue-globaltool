namespace Hue.CommandLine.Rendering.Abstractions;

using Common.Domain;

public interface IHueResourceRenderer
{
    void Render<T>(IEnumerable<T> resources) where T : Resource;
}
