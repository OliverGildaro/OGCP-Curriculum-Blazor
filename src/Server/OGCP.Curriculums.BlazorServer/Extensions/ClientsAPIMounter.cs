using OGCP.Curriculums.Shared.Clients;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Utils;

namespace OGCP.Curriculums.BlazorServer.Extensions;

public static class ClientsAPIMounter
{
    public static IServiceCollection SetupAPIClients(this IServiceCollection services)
    {
        services.AddSingleton<JsonSerializerOptionsWrapper>();
        services.AddHttpClient("profilesAPIClient",
            configureClient =>
            {
                //configureClient.BaseAddress = new Uri("https://app-cvs-southbraz-dev-001-gubrcpe9a6bhg7hp.brazilsouth-01.azurewebsites.net");
                configureClient.BaseAddress = new Uri("https://localhost:7080");
                configureClient.Timeout = new TimeSpan(0, 0, 30);//Set timeout to cancel the request
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new SocketsHttpHandler();//Primary handler
                handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
                handler.AllowAutoRedirect = true;//to allot redirect responses
                return handler;
            });

        services.AddScoped<IProfilesClient, ProfilesClient>();

        return services;
    }
}
