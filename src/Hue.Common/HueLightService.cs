namespace Hue.Common;

using System.Net.Http.Json;
using Abstractions;
using Domain;
using Domain.Lights;

public class HueLightService : IHueLightService
{
    public async Task<HueApiResponse<GetLight>?> Get(string id, CancellationToken cancellationToken)
    {
        try
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;

            using var httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Add("hue-application-key", "QhQ9L7S-u9zELshxZy0iik-74QEK-MCQeJXlRFPS");

            return await httpClient.GetFromJsonAsync<HueApiResponse<GetLight>>(
                $"https://192.168.1.118/clip/v2/resource/light/{id}",
                cancellationToken);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task Put(string id, PutLight putLight, CancellationToken cancellationToken)
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;

        using var httpClient = new HttpClient(handler);
        httpClient.DefaultRequestHeaders.Add("hue-application-key", "QhQ9L7S-u9zELshxZy0iik-74QEK-MCQeJXlRFPS");

        await httpClient.PutAsJsonAsync(
            $"https://192.168.1.118/clip/v2/resource/light/{id}",
            putLight,
            cancellationToken);
    }
}
