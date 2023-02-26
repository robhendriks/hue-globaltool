namespace Hue.GlobalTool.Feature.Lights.Commands.GetLightList;

using Common.Domain;
using Common.Domain.Lights;
using MediatR;

// ReSharper disable once ClassNeverInstantiated.Global
public record GetLightListQuery : IRequest<HueApiResponse<GetLight>>;
