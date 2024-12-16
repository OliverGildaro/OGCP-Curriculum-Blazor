using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using OGCP.Curriculums.BlazorServer.Interfaces;
using OGCP.Curriculums.BlazorServer.Models;
using OGCP.Curriculums.BlazorServer.Utils;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace OGCP.Curriculums.BlazorServer.Clients;

public class ProfilesClient : IProfilesClient
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly JsonSerializerOptionsWrapper jsonSerializerOptions;

    public ProfilesClient(IHttpClientFactory httpClientFactory, JsonSerializerOptionsWrapper jsonSerializerOptions)
    {
        this.httpClientFactory = httpClientFactory ??
            throw new ArgumentNullException(nameof(httpClientFactory));
        this.jsonSerializerOptions = jsonSerializerOptions;
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
