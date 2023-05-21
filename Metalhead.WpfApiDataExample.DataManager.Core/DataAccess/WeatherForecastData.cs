using Metalhead.WpfApiDataExample.DataManager.Core.Models;

namespace Metalhead.WpfApiDataExample.DataManager.Core.DataAccess;

public class WeatherForecastData : IWeatherForecastData
{
    private static readonly string[] s_summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        // Typically this would access a database or call an API, but for this example just return dummy data.
        // If calling DB stored procedures, you could create a SqlDataAccess class containing LoadData<T> and SaveData<T> methods.
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = s_summaries[Random.Shared.Next(s_summaries.Length)]
        })
        .ToArray();
    }
}
