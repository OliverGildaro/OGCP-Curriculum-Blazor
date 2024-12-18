using Microsoft.AspNetCore.Components;
using OGCP.Components.Controls;
using OGCP.Curriculums.Shared.Interfaces;
using OGCP.Curriculums.Shared.Models.Profiles;

namespace OGCP.Curriculums.BlazorServer.Components.Pages;

public partial class CreateProfile
{
    [Inject]
    public IProfileService ProfileService { get; set; }
    private CreateProfileRequest Event = new CreateProfileRequest();

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
}



