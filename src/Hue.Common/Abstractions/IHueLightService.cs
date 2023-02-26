namespace Hue.Common.Abstractions;

using Domain;
using Domain.Lights;

public interface IHueLightService
{
    Task<HueApiResponse<GetLight>?> Get(string id, CancellationToken cancellationToken);
    Task Put(string id, PutLight putLight, CancellationToken cancellationToken);
}
