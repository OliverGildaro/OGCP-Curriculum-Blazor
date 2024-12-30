using OGCP.Curriculums.BlazorServer.Models;
using OGCP.Curriculums.Shared.Models;
using OGCP.Curriculums.Shared.Models.Profiles;

namespace OGCP.Curriculums.Shared.Interfaces;
public interface IProfileService
{
    Task<IEnumerable<Profile>> GetProfilesAsync();
    Task<Profile> GetProfileAsync(string eventId);
    Task CreateProfilesAsync(CreateProfileRequest profile);
    Task StoreToken(TokenCached token);
}