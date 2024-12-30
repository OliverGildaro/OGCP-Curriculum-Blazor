using Microsoft.Azure.Cosmos;
using OGCP.Curriculums.BlazorServer.Interfaces;
using OGCP.Curriculums.BlazorServer.Models;

namespace OGCP.Curriculums.BlazorServer.Clients;

public class CosmosClientAPI : ICosmosClientAPI
{
    private readonly Container container;

    public CosmosClientAPI(
        string accountEndpoint,
        string authKey,
        string databaseId,
        string containerId)
    {
        var client = new CosmosClient(accountEndpoint, authKey, new CosmosClientOptions {});
        this.container = client.GetContainer(databaseId, containerId);
    }

    public async Task CreateTokenAsync(TokenCached item)
    {
        var response = await container.CreateItemAsync(item);
        var tokenCached = response.Resource;
    }

    public async Task<TokenCached> GetTokenAsyn(string id, string idToken)
    {
        return await container.ReadItemAsync<TokenCached>(id, new PartitionKey(idToken));
    }

    public async Task UpsertItemAsync(TokenCached item)
    {
        await container.UpsertItemAsync(item);
    }
}
