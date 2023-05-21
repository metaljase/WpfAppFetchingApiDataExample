# What is WpfAppFetchingApiDataExample?
WpfAppFetchingApiDataExample is an example of how a .NET WPF app can fetch data from an ASP.NET Web API and display it.

The .NET solution contains four projects, which include:
- ASP.NET Web API, based on the weather forecast project included with Visual Studio as a template.
- .NET WPF app to display the dummy weather forecast data from the API, using DI, MVVM and XAML.
- Class library for the WPF app.
- Class library for data access.

NOTE: Exception handling, resilient HTTP calls, proper logging etc, have been omitted on purpose to simplify this example.

# Setup instructions
1) Clone the WpfAppFetchingApiDataExample repository.

2) Open the .NET solution in Visual Studio 2022 (or a compatible alternative).

3) Set both `WpfApiDataExample.DataManager.Api` and `WpfApiDataExample.UI.Wpf` as startup projects.

4) Build the solution and run.

5) The API should open in a web browser window.  Make a note of the URL, and stop the app.

6) Open `appsettings.json` in `WpfApiDataExample.UI.Wpf` and update `ApiBaseUrl` with the URL from the previous step.

7) Build the solution and run.

8) The API should open in a web browser and also the WPF app should open displaying the weather forecast.
