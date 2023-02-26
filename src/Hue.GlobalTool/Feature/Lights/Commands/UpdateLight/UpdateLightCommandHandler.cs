namespace Hue.GlobalTool.Feature.Lights.Commands.UpdateLight;

using Common.Domain;
using Hue.Common.Abstractions;
using MediatR;

public class UpdateLightCommandHandler : IRequestHandler<UpdateLightCommand, HueApiResponse<ResourceIdentifier>>
{
    private readonly IHueLightService _lightService;

    public UpdateLightCommandHandler(IHueLightService lightService)
    {
        _lightService = lightService;
    }

    public Task<HueApiResponse<ResourceIdentifier>> Handle(UpdateLightCommand request,
        CancellationToken cancellationToken)
    {
        return _lightService.PutAsync(
            request.Id,
            request.CreatePutLight(),
            cancellationToken);
    }
}
