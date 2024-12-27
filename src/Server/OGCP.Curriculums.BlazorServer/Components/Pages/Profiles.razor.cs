using Microsoft.AspNetCore.Components;
using OGCP.Components.Controls;
using OGCP.Curriculums.BlazorServer.Helpers;
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
    public ErrorManager Errors = new ErrorManager();
    protected override async Task OnInitializedAsync()
    {
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

    private void ValidateField(string propertyName, string value)
    {
        Errors.ClearError(propertyName);

        if (propertyName == nameof(ProfileToCreate.GivenName))
        {
            ProfileToCreate.GivenName = value;
            if (string.IsNullOrWhiteSpace(value))
            {
                Errors.SetError(propertyName, "Given name is required.", "text-danger");
            }
            else if (value.Length > 10)
            {
                Errors.SetError(propertyName, "Given name cannot exceed 10 characters.", "text-danger");
            }
        }
        else if (propertyName == nameof(ProfileToCreate.FamilyNames))
        {
            ProfileToCreate.FamilyNames = value;

            if (string.IsNullOrWhiteSpace(value))
            {
                Errors.SetError(propertyName, "Family names are required.", "text-danger");
            }
            else if (value.Length > 10)
            {
                Errors.SetError(propertyName, "Family names cannot exceed 10 characters.", "text-danger");
            }
        }
    }
}