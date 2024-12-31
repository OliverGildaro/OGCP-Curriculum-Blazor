using OGCP.Curriculums.Shared.Clients;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Services;
using OGCP.Curriculums.Shared.Utils;

namespace OGCP.Curriculums.BlazorServer.Extensions;
public static class ServicesMounter
{
    public static IServiceCollection SetupServices(this IServiceCollection services)
    {
        services.AddScoped<IProfileService, ProfileService>();
        return services;
    }
}
