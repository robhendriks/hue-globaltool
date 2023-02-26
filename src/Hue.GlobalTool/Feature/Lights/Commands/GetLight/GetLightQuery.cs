namespace Hue.GlobalTool.Feature.Lights.Commands.GetLight;

using Hue.Common.Domain;
using Hue.Common.Domain.Lights;
using Enums;
using MediatR;

// ReSharper disable once ClassNeverInstantiated.Global
public record GetLightQuery(string Id, Output Output) : IRequest<HueApiResponse<GetLight>>;
