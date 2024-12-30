using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Caching.Cosmos;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using OGCP.Curriculums.BlazorServer.Components;
using OGCP.Curriculums.BlazorServer.Extensions;
using OGCP.Curriculums.BlazorServer.Helpers;

namespace OGCP.Curriculums.BlazorServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var initialScopes = builder.Configuration["CurriculumsApi:Scopes"]?.Split(' ');
        
        builder.Services.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
        {
            cacheOptions.DiagnosticsHandler = captureDiagnostics;
            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(
              builder.Configuration["Cosmos:AccountEndpoint"],
              builder.Configuration["Cosmos:AccountKey"]
            )
              .WithApplicationRegion("Central US");
            cacheOptions.ContainerName = builder.Configuration["Cosmos:CacheContainer"];
            cacheOptions.DatabaseName = builder.Configuration["Cosmos:CacheDatabase"];
            cacheOptions.ClientBuilder = clientBuilder;
            /* Creates the container if it does not exist */
            cacheOptions.CreateIfNotExists = true;
        });

        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"))
                        .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
                       .AddDistributedTokenCaches(); // Use distributed cache

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(3600);
            options.Cookie.IsEssential = true;
        });

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
        app.UseSession();
        app.UseStaticFiles();
        // Agregar middleware de autenticación y autorización
        app.UseRouting();
        app.UseAntiforgery();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }

    static void captureDiagnostics(CosmosDiagnostics diagnostics)
    {
        if (diagnostics.GetClientElapsedTime() > TimeSpan.FromMinutes(1))
        {
            Console.WriteLine(diagnostics.ToString());
        }
    }

}

