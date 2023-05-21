using Metalhead.WpfApiDataExample.UI.Core.Models;

namespace Metalhead.WpfApiDataExample.UI.Core.Api;
public interface IWeatherForecastEndpoint
{
    Task<IEnumerable<WeatherForecast>?> GetWeatherForecastsAsync();
}