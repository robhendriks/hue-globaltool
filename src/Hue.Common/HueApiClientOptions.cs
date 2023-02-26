namespace Hue.Common;

using Microsoft.Extensions.Logging;

public class HueApiClientOptions
{
    public HueApiClientOptions(ILogger logger, Uri baseUri)
    {
        Logger = logger;
        BaseUri = baseUri;
    }

    public readonly ILogger Logger;
    public readonly Uri BaseUri;
}
