namespace Hue.GlobalTool.Application.Lights.Commands.GetLight;

using Common.Abstractions;
using Common.Domain;
using Common.Domain.Lights;
using MediatR;

public class GetLightQueryHandler : IRequestHandler<GetLightQuery, HueApiResponse<GetLight>?>
{
    private readonly IHueLightService _lightService;

    public GetLightQueryHandler(IHueLightService lightService)
    {
        _lightService = lightService;
    }

    public async Task<HueApiResponse<GetLight>?> Handle(GetLightQuery request, CancellationToken cancellationToken)
    {
        return await _lightService.Get(request.Id, cancellationToken);
    }
}
