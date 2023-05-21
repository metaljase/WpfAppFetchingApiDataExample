using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Windows;

using Metalhead.WpfApiDataExample.UI.Core.Api;
using Metalhead.WpfApiDataExample.UI.Wpf.ViewModels;
using Metalhead.WpfApiDataExample.UI.Wpf.Views;

namespace Metalhead.WpfApiDataExample.UI.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IHost Host { get; }

    public App()
    {        
        Host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(hostConfig =>
            {
                hostConfig.SetBasePath(Directory.GetCurrentDirectory());
            })
            .ConfigureAppConfiguration((hostingContext, hostConfig) =>
            {
                hostConfig.AddConfiguration(GetConfiguration(hostConfig));
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<ILogger, DebugLogger>();
                services.AddSingleton<ApiHelper>();
                services.AddSingleton<WeatherForecastEndpoint>();

                services.AddSingleton<ShellViewModel>();
                services.AddTransient<WeatherForecastViewModel>();

                services.AddSingleton<ShellView>();
                services.AddTransient<WeatherForecastView>();

                // HttpClient needs to be registered after ApiHelper otherwise BaseAddress etc will not be set.
                string apiUrl = hostContext.Configuration.GetValue<string>("ApiBaseUrl")!;
                services.AddHttpClient<ApiHelper>(client =>
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });
            })
            .Build();
    }

    public new static App Current => (App)Application.Current;

    private static IConfigurationRoot GetConfiguration(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);

        return builder.Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await Host!.StartAsync();

        try
        {
            Host.Services.GetRequiredService<ShellView>().Show();

            base.OnStartup(e);
        }
        catch (Exception)
        {
            ILogger logger = Host.Services.GetRequiredService<ILogger>();
            logger.Log("Application exited unexpectedly.");
            Environment.Exit(0);
        }
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await Host!.StopAsync();
        base.OnExit(e);
    }
}
