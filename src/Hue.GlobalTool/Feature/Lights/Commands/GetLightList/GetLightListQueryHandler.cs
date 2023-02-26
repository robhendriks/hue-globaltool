namespace Hue.GlobalTool.Feature.Lights.Commands.GetLightList;

using Common.Abstractions;
using Common.Domain;
using Common.Domain.Lights;
using MediatR;

public class GetLightListQueryHandler : IRequestHandler<GetLightListQuery, HueApiResponse<GetLight>>
{
    private readonly IHueLightService _lightService;

    public GetLightListQueryHandler(IHueLightService lightService)
    {
        _lightService = lightService;
    }

    public Task<HueApiResponse<GetLight>> Handle(GetLightListQuery request, CancellationToken cancellationToken)
    {
        return _lightService.GetAllAsync(cancellationToken);
    }
}
