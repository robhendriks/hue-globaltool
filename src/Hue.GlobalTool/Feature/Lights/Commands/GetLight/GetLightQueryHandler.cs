namespace Hue.GlobalTool.Feature.Lights.Commands.GetLight;

using Common.Domain;
using Common.Domain.Lights;
using Common.Services.Abstractions;
using MediatR;

public class GetLightQueryHandler : IRequestHandler<GetLightQuery, HueApiResponse<GetLight>>
{
    private readonly IHueLightService _lightService;

    public GetLightQueryHandler(IHueLightService lightService)
    {
        _lightService = lightService;
    }

    public Task<HueApiResponse<GetLight>> Handle(GetLightQuery request, CancellationToken cancellationToken)
    {
        return _lightService.GetAsync(request.Id, cancellationToken);
    }
}
