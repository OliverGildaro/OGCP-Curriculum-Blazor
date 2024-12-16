using OGCP.Curriculums.Shared.Models;

namespace OGCP.Curriculums.Shared.Interfaces;
public interface IProfilesClient
{
    Task<IEnumerable<Profile>> GetProfilesAsync();
    Task<Profile> GetProfileAsync(string eventId);
}