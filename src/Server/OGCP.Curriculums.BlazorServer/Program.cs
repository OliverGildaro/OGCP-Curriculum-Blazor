using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using OGCP.Curriculums.BlazorServer.Components;
using OGCP.Curriculums.BlazorServer.Extensions;
using OGCP.Curriculums.BlazorServer.Helpers;

namespace OGCP.Curriculums.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var initialScopes = builder.Configuration["CurriculumsApi:Scopes"]?.Split(' ');
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"))
                            .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
                            .AddInMemoryTokenCaches();
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Agrega servicios adicionales de autorización
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
            });

            // Agrega UI para el consentimiento
            builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();


            builder.Services.AddServicesToContainer();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            // Agregar middleware de autenticación y autorización
            app.UseRouting();
            app.UseAntiforgery();
            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                if (!context.User.Identity?.IsAuthenticated ?? false)
                {
                    await context.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme);
                    return;
                }

                await next();
            });


            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
