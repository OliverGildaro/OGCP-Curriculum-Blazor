using Microsoft.AspNetCore.Components;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Models;
using OGCP.Curriculums.Shared.Models.Profiles;

namespace OGCP.Curriculums.BlazorServer.Components.Pages;
public partial class Profiles
{
    [Inject]
    public IProfileService eventService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public IEnumerable<Profile> profiles { get; private set; } = Enumerable.Empty<Profile>();

    public CreateProfileRequest ProfileToCreate = new CreateProfileRequest();
    protected override async Task OnInitializedAsync()
    {
        //var profilesResult = await this.eventService.GetProfilesAsync();
        //profiles = profilesResult;
        await base.OnInitializedAsync();
    }

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
}