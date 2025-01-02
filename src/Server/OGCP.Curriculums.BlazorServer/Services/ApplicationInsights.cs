using OGCP.Curriculums.BlazorServer.Interfaces;

namespace OGCP.Curriculums.BlazorServer.Services;

public class ApplicationInsights : IApplicationInsights
{
    private readonly ILogger<ApplicationInsights> _logger;

    public ApplicationInsights(ILogger<ApplicationInsights> logger)
    {
        _logger = logger;
    }

    // Logs a simple informational message
    public void ApplicationInsightsLogger()
    {
        _logger.LogInformation("ApplicationInsightsLogger Method was called.");
    }

    // Logs an informational message
    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    // Logs a warning message
    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
    }

    // Logs an error message
    public void LogError(string message)
    {
        _logger.LogError(message);
    }

    // Logs an exception with an optional custom message
    public void LogException(Exception exception, string customMessage = null)
    {
        if (string.IsNullOrEmpty(customMessage))
        {
            _logger.LogError(exception, "An exception occurred.");
        }
        else
        {
            _logger.LogError(exception, customMessage);
        }
    }
}
