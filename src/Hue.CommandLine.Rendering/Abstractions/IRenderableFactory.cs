namespace Hue.CommandLine.Rendering.Abstractions;

using Common.Domain;
using Spectre.Console.Rendering;

public interface IRenderableFactory<T>
{
    IRenderable Create(HueApiResponse<T> apiResponse);
}
