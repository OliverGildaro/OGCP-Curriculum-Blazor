namespace OGCP.Curriculums.BlazorServer.Extensions;

public static class RazorComponentsMounter
{
    public static IServiceCollection SetupRazorComponents(
        this IServiceCollection Services)
    {
 
        // Add services to the container.
        Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        return Services;
    }
}
