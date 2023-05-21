using System.Diagnostics;

namespace Metalhead.WpfApiDataExample.DataManager.Api;

public class DebugLogger : ILogger
{
    public void Log(string message)
    {
        Debug.WriteLine(message);
    }
}
