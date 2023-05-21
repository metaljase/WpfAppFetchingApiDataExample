using Microsoft.AspNetCore.Mvc;

using Metalhead.WpfApiDataExample.DataManager.Core.DataAccess;
using Metalhead.WpfApiDataExample.DataManager.Core.Models;

namespace Metalhead.WpfApiDataExample.DataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastData _weatherForecastData;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastData weatherForecastData)
    {
        _logger = logger;
        _weatherForecastData = weatherForecastData;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Getting weather forecasts");
        return _weatherForecastData.GetWeatherForecast();
    }
}