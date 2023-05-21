using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

using Metalhead.WpfApiDataExample.UI.Core.Api;
using Metalhead.WpfApiDataExample.UI.Core.Models;

namespace Metalhead.WpfApiDataExample.UI.Wpf.ViewModels;

public partial class WeatherForecastViewModel : ObservableObject
{
    public ObservableCollection<WeatherForecast>? Forecasts { get; set; }
    private WeatherForecastEndpoint WeatherForecastEndpoint { get; }

    public WeatherForecastViewModel(WeatherForecastEndpoint weatherForecastEndpoint)
    {
        WeatherForecastEndpoint = weatherForecastEndpoint;
        GetWeatherForecasts();
    }

    [RelayCommand]
    public void Refresh()
    {
        GetWeatherForecasts();
    }

    public async void GetWeatherForecasts()
    {
        var forecasts = await WeatherForecastEndpoint.GetWeatherForecastsAsync();
        if (forecasts is null)
        {
            MessageBox.Show("Failed to fetch weather forecasts");
            return;
        }
        
        Forecasts = new ObservableCollection<WeatherForecast>(forecasts);
        OnPropertyChanged(nameof(Forecasts));
    }
}
