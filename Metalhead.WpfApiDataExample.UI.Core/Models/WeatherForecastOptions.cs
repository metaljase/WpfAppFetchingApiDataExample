using System.ComponentModel.DataAnnotations;

namespace Metalhead.WpfApiDataExample.UI.Core.Models;

public class WeatherForecastOptions
{
    public const string WeatherForecast = "WeatherForecast";

    [Required]
    public required string ApiBaseUrl { get; set; }
}
