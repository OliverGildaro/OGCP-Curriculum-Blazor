using Microsoft.Extensions.Logging.ApplicationInsights;
using OGCP.Curriculums.BlazorServer.Extensions;

namespace OGCP.Curriculums.BlazorServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        try
        {
            string appInsightsCS = builder.Configuration["ApplicationInsights:ConnectionString"];
            builder.Logging.AddApplicationInsights(
                    configureTelemetryConfiguration: (config) =>
                        config.ConnectionString = appInsightsCS,
                        configureApplicationInsightsLoggerOptions: (options) => { }
                );

            builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>(null, LogLevel.Trace);

            builder
                .ConfigureServices()
                .ConfigurePipeline()
                .Run();
        }
        catch (Exception)
        {

            throw;
        }




        var app = builder.Build();
    }
}
