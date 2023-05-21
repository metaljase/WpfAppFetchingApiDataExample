using System.Text.Json.Serialization;

namespace Metalhead.WpfApiDataExample.UI.Core.Models;

// This class is the model for the UI.  Do not use this class for the data source.
public class WeatherForecast
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("temperatureC")]
    public int TemperatureC { get; set; }

    [JsonPropertyName("temperatureF")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
}