using Microsoft.Extensions.Logging.ApplicationInsights;
using OGCP.Curriculums.BlazorServer.Extensions;

namespace OGCP.Curriculums.BlazorServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ILogger logger = null;

        try
        {
            string appInsightsCS = builder.Configuration["ApplicationInsights:ConnectionString"];
            builder.Logging.AddApplicationInsights(
                    configureTelemetryConfiguration: (config) =>
                        config.ConnectionString = appInsightsCS,
                        configureApplicationInsightsLoggerOptions: (options) => { }
                );

            builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>(null, LogLevel.Trace);


            var app = builder
                .ConfigureServices()
                .ConfigurePipeline();

            var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
            logger = loggerFactory.CreateLogger("OGCP");

            app.Run();
            logger.LogInformation("MY_TRACKINGS: Start running blazor application");

        }
        catch (Exception)
        {

            throw;
        }
    }
}
