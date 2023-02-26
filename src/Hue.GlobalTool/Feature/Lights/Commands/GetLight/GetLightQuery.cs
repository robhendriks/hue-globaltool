namespace Hue.GlobalTool.Feature.Lights.Commands.GetLight;

using Hue.Common.Domain;
using Hue.Common.Domain.Lights;
using Hue.GlobalTool.Enums;
using MediatR;

public record GetLightQuery(string Id, Output Output) : IRequest<HueApiResponse<GetLight>>;
