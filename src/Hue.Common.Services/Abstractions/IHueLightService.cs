namespace Hue.Common.Services.Abstractions;

using Domain;
using Domain.Lights;

public interface IHueLightService
{
    Task<HueApiResponse<GetLight>> GetAsync(string id, CancellationToken cancellationToken);
    Task<HueApiResponse<GetLight>> GetAllAsync(CancellationToken cancellationToken);

    Task<HueApiResponse<ResourceIdentifier>>
        PutAsync(string id, PutLight putLight, CancellationToken cancellationToken);
}
