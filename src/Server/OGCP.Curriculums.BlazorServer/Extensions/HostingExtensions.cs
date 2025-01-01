using OGCP.Curriculums.BlazorServer.Helpers;
using OGCP.Curriculums.BlazorServer.Components;


namespace OGCP.Curriculums.BlazorServer.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        try
        {
            builder.Services.SetupRazorComponents();
            builder.Services.SetupServices();
            builder.Services.SetupAPIClients(builder.Configuration);
            builder.Services.SetupAzureServices(builder.Configuration);
            return builder.Build();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {

        app.UseMiddleware<ExceptionMiddleware>();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseSession();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAntiforgery();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        return app;
    }
}
