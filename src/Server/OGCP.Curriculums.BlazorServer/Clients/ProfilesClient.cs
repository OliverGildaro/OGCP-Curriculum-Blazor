using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Identity.Web;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Models;
using OGCP.Curriculums.Shared.Models.Profiles;
using OGCP.Curriculums.Shared.Utils;
using System.Net.Http.Headers;

namespace OGCP.Curriculums.Shared.Clients;

public class ProfilesClient : IProfilesClient
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly JsonSerializerOptionsWrapper jsonSerializerOptions;
    private readonly ITokenAcquisition tokenAdquisition;
    private readonly IConfiguration configure;

    public ProfilesClient(
        IHttpClientFactory httpClientFactory,
        JsonSerializerOptionsWrapper jsonSerializerOptions,
        //ITokenAcquisition tokenAdquisition,
        IConfiguration configure)
    {
        this.httpClientFactory = httpClientFactory ??
            throw new ArgumentNullException(nameof(httpClientFactory));
        this.jsonSerializerOptions = jsonSerializerOptions;
        //this.tokenAdquisition = tokenAdquisition;
        this.configure = configure;
    }

    public Task CreateProfilesAsync(CreateProfileRequest profile)
    {
        throw new NotImplementedException();
    }

    public async Task<Profile> GetProfileAsync(string eventId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Profile>> GetProfilesAsync()
    {
        var _httpClient = httpClientFactory.CreateClient("profilesAPIClient");
        _httpClient.DefaultRequestHeaders.Clear();

        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        //var scopes = configure["CurriculumsApi:Scopes"]?.Split(' ')!;

        //dado que implemente un cache distribuido usando cosmosDb
        //mi tokenAdquisition traera directamente el accessToken de cosmos
        //Si el token no se encuentra o ha expirado la traera de adb2c
        //tokenAdquisition sabe de donde traer la clave relacionada a la session de usuario
        //string accessToken = await tokenAdquisition.GetAccessTokenForUserAsync(scopes);
        //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        HttpResponseMessage response = null;
        try
        {
            response = await _httpClient.GetAsync("api/v1/profiles");
        }
        catch (Exception ex)
        {
            throw;
        }

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var events = System.Text.Json.JsonSerializer
                .Deserialize<ApiResponse>(content, jsonSerializerOptions.Options);

        return events.Result;
    }


}
