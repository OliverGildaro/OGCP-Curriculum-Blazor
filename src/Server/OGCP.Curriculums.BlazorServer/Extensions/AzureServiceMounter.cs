using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Caching.Cosmos;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace OGCP.Curriculums.BlazorServer.Extensions;

public static class AzureServiceMounter
{
    public static void SetupAzureServices(
        this IServiceCollection Services, IConfiguration Configuration)
    {
        SetupCosmos(Services, Configuration);
        SetupADB2C(Services, Configuration);
    }

    public static void SetupCosmos(
        IServiceCollection Services, IConfiguration Configuration)
    {
        //Registramos el cache distibuido de mongo
        Services.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
        {
            cacheOptions.DiagnosticsHandler = captureDiagnostics;
            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(
                Configuration["Cosmos:AccountEndpoint"],
                Configuration["Cosmos:AccountKey"]
            )
                .WithApplicationRegion("Central US");
            cacheOptions.ContainerName = Configuration["Cosmos:CacheContainer"];
            cacheOptions.DatabaseName = Configuration["Cosmos:CacheDatabase"];
            cacheOptions.ClientBuilder = clientBuilder;
            /* Creates the container if it does not exist */
            cacheOptions.CreateIfNotExists = true;
        });

        Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(3600);
            options.Cookie.IsEssential = true;
        });
    }

    public static void SetupADB2C(
        IServiceCollection Services, IConfiguration Configuration)
    {
        var initialScopes = Configuration["CurriculumsApi:Scopes"]?.Split(' ');

        //Registramos la auth con ADB2C
        Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAdB2C"))
                .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
                .AddDistributedTokenCaches(); // Use distributed cache

        // Agrega servicios adicionales de autorización
        Services.AddAuthorization(options =>
        {
            options.FallbackPolicy = options.DefaultPolicy;
        });

        // Agrega UI para el consentimiento
        Services.AddControllersWithViews()
            .AddMicrosoftIdentityUI();
    }

    private static void captureDiagnostics(CosmosDiagnostics diagnostics)
    {
        if (diagnostics.GetClientElapsedTime() > TimeSpan.FromMinutes(1))
        {
            Console.WriteLine(diagnostics.ToString());
        }
    }
}
