using OGCP.Curriculums.BlazorServer.Models;

namespace OGCP.Curriculums.BlazorServer.Interfaces;
public interface IProfilesClient
{
    Task<IEnumerable<Profile>> GetProfilesAsync();
    Task<Profile> GetProfileAsync(string eventId);
}