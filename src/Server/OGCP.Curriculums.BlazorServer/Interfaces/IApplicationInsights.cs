namespace OGCP.Curriculums.BlazorServer.Interfaces;
public interface IApplicationInsights
{
    void ApplicationInsightsLogger();
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
    void LogException(Exception exception, string customMessage = null);
}

