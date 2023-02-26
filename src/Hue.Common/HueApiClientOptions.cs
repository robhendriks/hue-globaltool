namespace Hue.Common;

using Microsoft.Extensions.Logging;

public class HueApiClientOptions
{
    public HueApiClientOptions(ILogger logger, Uri baseUri, TimeSpan timeout)
    {
        Logger = logger;
        BaseUri = baseUri;
        Timeout = timeout;
    }

    public readonly ILogger Logger;
    public readonly Uri BaseUri;
    public readonly TimeSpan Timeout;
}
