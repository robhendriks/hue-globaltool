namespace Hue.Common;

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Abstractions;
using Domain;
using Microsoft.Extensions.Logging;

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
            }
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

            httpResponseMessage.EnsureSuccessStatusCode();

            Console.WriteLine(await httpResponseMessage.Content.ReadAsStringAsync());
            
            apiResponse = await httpResponseMessage.Content.ReadFromJsonAsync<HueApiResponse<TResponse>>(
                DefaultJsonSerializerOptions,
                cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _options.Logger.LogError(exception, "GET operation failed.");
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
                cancellationToken);

            httpResponseMessage.EnsureSuccessStatusCode();

            apiResponse = await httpResponseMessage.Content.ReadFromJsonAsync<HueApiResponse<TResponse>>(
                DefaultJsonSerializerOptions,
                cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            _options.Logger.LogError(exception, "PUT operation failed.");
        }

        return apiResponse ?? new HueApiResponse<TResponse>();
    }
}
