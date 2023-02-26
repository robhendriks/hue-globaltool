namespace Hue.GlobalTool.Feature.Lights.Commands.UpdateLight;

using Hue.Common.Domain.Lights;

public static class UpdateLightCommandExtensions
{
    public static PutLight CreatePutLight(this UpdateLightCommand request)
    {
        var updateLight = new PutLight();

        if (request.On is { } on)
        {
            updateLight.On = new PutLightOn
            {
                On = on
            };
        }

        if (request.Brightness is { } brightness)
        {
            updateLight.Dimming = new PutLightDimming
            {
                Brightness = brightness
            };
        }

        if (request.ColorTemperature is { } colorTemperature)
        {
            updateLight.ColorTemperature = new PutLightColorTemperature
            {
                Mirek = colorTemperature
            };
        }

        return updateLight;
    }
}
