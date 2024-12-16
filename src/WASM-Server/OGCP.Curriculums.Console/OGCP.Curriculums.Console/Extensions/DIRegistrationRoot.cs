using OGCP.Curriculums.Shared.Extensions;

namespace OGCP.Curriculums.Console.Extensions;
public static class DIRegistrationRoot
{
    public static void AddServicesToContainer(this IServiceCollection services)
    {
        services.AddServices();
    }
}