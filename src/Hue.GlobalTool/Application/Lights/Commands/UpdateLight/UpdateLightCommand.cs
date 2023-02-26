namespace Hue.GlobalTool.Application.Lights.Commands.UpdateLight;

using MediatR;

public record UpdateLightCommand
    (string Id, bool? On, int? Brightness, int? ColorTemperature) : IRequest<Unit>;
