namespace Hue.Common.ApiClient;

public class HueApiClientOptions
{
    public HueApiClientOptions(Uri baseUri, TimeSpan timeout)
    {
        BaseUri = baseUri;
        Timeout = timeout;
    }

    public readonly Uri BaseUri;
    public readonly TimeSpan Timeout;
}
