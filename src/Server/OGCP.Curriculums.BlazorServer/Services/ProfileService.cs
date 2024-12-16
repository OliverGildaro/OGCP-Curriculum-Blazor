using OGCP.Curriculums.BlazorServer.Interfaces;
using OGCP.Curriculums.BlazorServer.Models;

namespace OGCP.Curriculums.BlazorServer.Services;

public class ProfileService : IProfileService
{
    private readonly IProfilesClient client;

    public ProfileService(IProfilesClient client)
    {
        this.client = client;
    }
    public Task<IEnumerable<Profile>> GetProfilesAsync()
    {
        return this.client.GetProfilesAsync();
    }

    public Task<Profile> GetProfileAsync(string eventId)
    {
        throw new NotImplementedException();
    }
}
