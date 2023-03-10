namespace Hue.Common.ApiClient;

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Abstractions;
using Domain;

public class HueApiClient : IHueApiClient
{
    private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private readonly HueApiClientOptions _options;

    public HueApiClient(HueApiClientOptions options)
    {
        _options = options;
    }

    private HttpClient CreateHttpClient()
    {
        var handler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true
        };

        return new HttpClient(handler)
        {
            BaseAddress = _options.BaseUri,
            DefaultRequestHeaders =
            {
                {"hue-application-key", "QhQ9L7S-u9zELshxZy0iik-74QEK-MCQeJXlRFPS"}
            },
            Timeout = _options.Timeout
        };
    }

    public async Task<HueApiResponse<TResponse>> GetFromJsonAsync<TResponse>(string requestUri,
        CancellationToken cancellationToken)
    {
        var httpClient = CreateHttpClient();

        HueApiResponse<TResponse>? apiResponse = null;

        try
        {
            var httpResponseMessage = await httpClient.GetAsync(
                requestUri,
                cancellationToken);

            // httpResponseMessage.EnsureSuccessStatusCode();

            apiResponse = await httpResponseMessage.Content.ReadFromJsonAsync<HueApiResponse<TResponse>>(
                DefaultJsonSerializerOptions,
                cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            // TODO: handle exceptions
        }

        return apiResponse ?? new HueApiResponse<TResponse>();
    }

    public async Task<HueApiResponse<TResponse>> PutAsJsonAsync<TRequest, TResponse>(string requestUri,
        TRequest request, CancellationToken cancellationToken)
    {
        var httpClient = CreateHttpClient();

        HueApiResponse<TResponse>? apiResponse = null;

        try
        {
            var httpResponseMessage = await httpClient.PutAsJsonAsync(
                requestUri,
                request,
                DefaultJsonSerializerOptions,
                cancellationToken);

            // httpResponseMessage.EnsureSuccessStatusCode();

            apiResponse = await httpResponseMessage.Content.ReadFromJsonAsync<HueApiResponse<TResponse>>(
                DefaultJsonSerializerOptions,
                cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            // TODO: handle exceptions
        }

        return apiResponse ?? new HueApiResponse<TResponse>();
    }
}
