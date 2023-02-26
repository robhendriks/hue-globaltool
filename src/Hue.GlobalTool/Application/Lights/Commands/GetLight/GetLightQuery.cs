namespace Hue.GlobalTool.Application.Lights.Commands.GetLight;

using Common.Domain;
using Common.Domain.Lights;
using Enums;
using MediatR;

public record GetLightQuery(string Id, Output Output) : IRequest<HueApiResponse<GetLight>?>;
