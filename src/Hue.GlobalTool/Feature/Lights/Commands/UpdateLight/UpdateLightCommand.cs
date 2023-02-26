namespace Hue.GlobalTool.Feature.Lights.Commands.UpdateLight;

using Common.Domain;
using MediatR;

// ReSharper disable once ClassNeverInstantiated.Global
public record UpdateLightCommand
    (string Id, bool? On, int? Brightness, int? ColorTemperature) : IRequest<HueApiResponse<ResourceIdentifier>>;
