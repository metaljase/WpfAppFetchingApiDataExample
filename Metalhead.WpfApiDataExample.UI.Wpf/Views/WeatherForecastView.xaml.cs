using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

using Metalhead.WpfApiDataExample.UI.Wpf.ViewModels;

namespace Metalhead.WpfApiDataExample.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for WeatherForecastView.xaml
    /// </summary>
    public partial class WeatherForecastView : UserControl
    {
        public WeatherForecastView()
        {
            InitializeComponent();

            DataContext = App.Current.Host.Services.GetService<WeatherForecastViewModel>();
        }
    }
}
