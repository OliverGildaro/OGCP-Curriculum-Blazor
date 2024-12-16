using OGCP.Curriculums.BlazorServer.Clients;
using OGCP.Curriculums.BlazorServer.Components;
using OGCP.Curriculums.BlazorServer.Interfaces;
using OGCP.Curriculums.BlazorServer.Services;
using OGCP.Curriculums.BlazorServer.Utils;

namespace OGCP.Curriculums.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSingleton<JsonSerializerOptionsWrapper>();
            builder.Services.AddHttpClient("profilesAPIClient",
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

            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IProfilesClient, ProfilesClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
