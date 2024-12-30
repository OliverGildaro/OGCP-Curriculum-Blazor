using OGCP.Curriculums.Shared.Models;
using OGCP.Curriculums.Shared.Models.Profiles;

namespace OGCP.Curriculums.Shared.Interfaces;
public interface IProfilesClient
{
    Task<IEnumerable<Profile>> GetProfilesAsync();
    Task CreateProfilesAsync(CreateProfileRequest profile);
    Task<Profile> GetProfileAsync(string eventId);
}