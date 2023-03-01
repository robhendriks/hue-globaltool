namespace Hue.Common.Services;

using Domain;
using Domain.Lights;
using Abstractions;
using ApiClient.Abstractions;

public class HueLightService : IHueLightService
{
    private readonly IHueApiClient _apiClient;

    public HueLightService(IHueApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<HueApiResponse<GetLight>> GetAsync(string id, CancellationToken cancellationToken)
    {
        return _apiClient.GetFromJsonAsync<GetLight>(
            $"clip/v2/resource/light/{id}",
            cancellationToken);
    }

    public Task<HueApiResponse<GetLight>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _apiClient.GetFromJsonAsync<GetLight>(
            "clip/v2/resource/light",
            cancellationToken);
    }

    public Task<HueApiResponse<ResourceIdentifier>> PutAsync(string id, PutLight putLight,
        CancellationToken cancellationToken)
    {
        return _apiClient.PutAsJsonAsync<PutLight, ResourceIdentifier>(
            $"clip/v2/resource/light/{id}",
            putLight,
            cancellationToken);
    }
}
