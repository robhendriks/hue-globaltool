namespace Hue.Common.ApiClient.Abstractions;

using Domain;

public interface IHueApiClient
{
    Task<HueApiResponse<TResponse>> GetFromJsonAsync<TResponse>(string requestUri, CancellationToken cancellationToken);

    Task<HueApiResponse<TResponse>> PutAsJsonAsync<TRequest, TResponse>(string requestUri, TRequest request,
        CancellationToken cancellationToken);
}
