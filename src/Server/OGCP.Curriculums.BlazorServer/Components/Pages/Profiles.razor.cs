using Microsoft.AspNetCore.Components;
using OGCP.Components.Controls;
using OGCP.Curriculums.BlazorServer.Models;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Models;

namespace OGCP.Curriculums.BlazorServer.Components.Pages;
public partial class Profiles
{
    [Inject]
    public IProfileService eventService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public IEnumerable<Profile> profiles { get; private set; } = Enumerable.Empty<Profile>();

    protected override async Task OnInitializedAsync()
    {
        //await this.SaveToken();
        var profilesResult = await this.eventService.GetProfilesAsync();
        profiles = profilesResult;
        await base.OnInitializedAsync();
    }

    private List<SelectOption> selectOptions = new()
    {
        new SelectOption { Value = ProfileRequests.CreateGeneral.ToString(), Label = "General" },
        new SelectOption { Value = ProfileRequests.CreateStudent.ToString(), Label = "Student" },
        new SelectOption { Value = ProfileRequests.CreateQualified.ToString(), Label = "Qualified" },
    };

    public void NavigateToDetails(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {

        }

        this.NavigationManager.NavigateTo($"profiles/{id}");
    }

    protected void HandleCreate()
    {
        this.NavigationManager.NavigateTo($"/createNewProfile");
    }

    //private async Task SaveToken()
    //{
    //    try
    //    {
    //        var accessToken = await TokenAcquisition
    //            .GetAccessTokenForUserAsync(new[] { "https://curriculumsogcp.onmicrosoft.com/3191a5cf-ebc6-4ae8-b6ef-ac6af990cc5b/access_as_user" });

    //        var tokenData = new TokenCached
    //        {
    //            Id = Guid.NewGuid().ToString(), // Unique identifier
    //            Token = accessToken,
    //        };

    //        await this.eventService.StoreToken(tokenData);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error storing token: {ex.Message}");
    //    }
    //}
}