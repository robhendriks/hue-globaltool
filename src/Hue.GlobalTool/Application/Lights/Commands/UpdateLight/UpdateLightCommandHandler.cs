namespace Hue.GlobalTool.Application.Lights.Commands.UpdateLight;

using Common.Abstractions;
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
        await _lightService.Put(
            request.Id,
            request.CreatePutLight(),
            cancellationToken);

        return Unit.Value;
    }
}
