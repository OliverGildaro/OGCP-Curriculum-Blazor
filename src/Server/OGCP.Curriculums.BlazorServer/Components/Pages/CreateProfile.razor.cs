using Microsoft.AspNetCore.Components;
using OGCP.Components.Controls;
using OGCP.Curriculums.BlazorServer.Helpers;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Models.Profiles;

namespace OGCP.Curriculums.BlazorServer.Components.Pages;

public partial class CreateProfile
{
    [Inject]
    public IProfileService ProfileService { get; set; }
    private CreateProfileRequest Event = new CreateProfileRequest();
    public ErrorManager Errors = new ErrorManager();
    public CreateProfileRequest ProfileToCreate = new CreateProfileRequest();

    public string Value { get; set; }

    private List<SelectOption> selectOptions = new()
    {
        new SelectOption { Value = ProfileRequests.CreateGeneral.ToString(), Label = "General" },
        new SelectOption { Value = ProfileRequests.CreateStudent.ToString(), Label = "Student" },
        new SelectOption { Value = ProfileRequests.CreateQualified.ToString(), Label = "Qualified" },
    };

    protected void OnValueChanged(string value)
    {
        var asas = value;
    }

    //lifecycle
    protected Task OnInitializeAsync()
    {
        return null;
    }

    //Fired when new values for parameter are received
    protected Task OnParameterSetAsync()
    {
        return null;
    }

    protected Task OnAfterRenderAsync()
    {
        return null;
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



