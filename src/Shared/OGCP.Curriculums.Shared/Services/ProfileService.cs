using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Models;

namespace OGCP.Curriculums.Shared.Services;

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
