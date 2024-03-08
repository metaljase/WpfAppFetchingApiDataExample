using System.Text.Json;

using Metalhead.WpfApiDataExample.UI.Core.Models;

namespace Metalhead.WpfApiDataExample.UI.Core.Api;

public class WeatherForecastEndpoint(ApiHelper apiHelper) : IWeatherForecastEndpoint
{
    private ApiHelper ApiHelper { get; } = apiHelper;

    public async Task<IEnumerable<WeatherForecast>?> GetWeatherForecastsAsync()
    {
        string response = await ApiHelper.Get("WeatherForecast");

        return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(response);
    }
}
