using Microsoft.Extensions.Configuration;
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
    private readonly ITokenAcquisition token;
    private readonly IConfiguration configure;

    public ProfilesClient(
        IHttpClientFactory httpClientFactory,
        JsonSerializerOptionsWrapper jsonSerializerOptions,
        ITokenAcquisition token,
        IConfiguration configure)
    {
        this.httpClientFactory = httpClientFactory ??
            throw new ArgumentNullException(nameof(httpClientFactory));
        this.jsonSerializerOptions = jsonSerializerOptions;
        this.token = token;
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

        var scopes = configure["CurriculumsApi:Scopes"]?.Split(' ')!;

        string accessToken = await token.GetAccessTokenForUserAsync(scopes);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

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
