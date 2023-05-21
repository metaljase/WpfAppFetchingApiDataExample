namespace Metalhead.WpfApiDataExample.DataManager.Core.Models;

// This class is the model for the data source.  Do not use this class in the UI.
public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}