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

    private string selectedValue;

    private List<SelectOption> selectOptions = new()
    {
        new SelectOption { Value = ProfileRequests.CreateGeneral, Label = "General" },
        new SelectOption { Value = ProfileRequests.CreateStudent, Label = "Student" },
        new SelectOption { Value = ProfileRequests.CreateQualified, Label = "Qualified" },
    };

    protected void HandleValueChanged()
    {

    }
}



