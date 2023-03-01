namespace Hue.CommandLine.Rendering.Abstractions;

using Common.Domain;

public interface IHueResourceIdentifierRenderer
{
    void Render<T>(IEnumerable<T> resourceIdentifiers) where T : ResourceIdentifier;
}
