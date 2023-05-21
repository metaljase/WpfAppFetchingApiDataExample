using Metalhead.WpfApiDataExample.DataManager.Core.Models;

namespace Metalhead.WpfApiDataExample.DataManager.Core.DataAccess;

public interface IWeatherForecastData
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}