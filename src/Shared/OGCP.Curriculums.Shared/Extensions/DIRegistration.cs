using Microsoft.Extensions.DependencyInjection;
using OGCP.Curriculums.Shared.Clients;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Services;
using OGCP.Curriculums.Shared.Utils;

namespace OGCP.Curriculums.Shared.Extensions;

public static class DIRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddSingleton<JsonSerializerOptionsWrapper>();
        services.AddHttpClient("profilesAPIClient",
            configureClient =>
            {
                configureClient.BaseAddress = new Uri("https://localhost:7080");
                configureClient.Timeout = new TimeSpan(0, 0, 30);//Set timeout to cancel the request
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new SocketsHttpHandler();//Primary handler
                handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
                handler.AllowAutoRedirect = true;//to allot redirect responses
                return handler;
            });

        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IProfilesClient, ProfilesClient>();
        return services;
    }
}
