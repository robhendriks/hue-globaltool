namespace Hue.GlobalTool.Feature.Lights.Commands.UpdateLight;

using Hue.Common.Abstractions;
using MediatR;

public class UpdateLightCommandHandler : IRequestHandler<UpdateLightCommand, Unit>
{
    private readonly IHueLightService _lightService;

    public UpdateLightCommandHandler(IHueLightService lightService)
    {
        _lightService = lightService;
    }

    public async Task<Unit> Handle(UpdateLightCommand request, CancellationToken cancellationToken)
    {
        await _lightService.PutAsync(
            request.Id,
            request.CreatePutLight(),
            cancellationToken);

        return Unit.Value;
    }
}
