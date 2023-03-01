namespace Hue.GlobalTool.Extensions;

using System.CommandLine;
using System.Numerics;

public static class OptionExtensions
{
    public static void AddRangeValidator<T>(this Option<T> option, T min, T max)
        where T : INumber<T>
    {
        option.AddValidator(result =>
        {
            var value = result.GetValueForOption(option);

            if (value != null && (value < min || value > max))
            {
                result.ErrorMessage = $"Value must be between {min} and {max}";
            }
        });
    }
}
