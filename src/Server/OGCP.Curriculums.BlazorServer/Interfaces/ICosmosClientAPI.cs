using OGCP.Curriculums.BlazorServer.Models;

namespace OGCP.Curriculums.BlazorServer.Interfaces
{
    public interface ICosmosClientAPI
    {
        Task UpsertItemAsync(TokenCached item);
        Task CreateTokenAsync(TokenCached item);
        Task<TokenCached> GetTokenAsyn(string id, string partKey);
    }
}
