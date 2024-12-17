namespace OGCP.Curriculums.Shared.Models.Profiles;

public class CreateProfileRequest
{
    public int Id { get; set; }
    public string GivenName { get; set; } = string.Empty;
    public string FamilyNames { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string? DesiredJobRole { get; set; }
    public List<string> PersonalGoals { get; set; } = new List<string>();
    public string? Major { get; set; }
    public string? CareerGoals { get; set; }
    public string Discriminator { get; set; } = string.Empty;
}

public class CreateQualifiedProfileRequest : CreateProfileRequest
{
    public string? DesiredJobRole { get; set; }
}

public class CreateGeneralProfileRequest : CreateProfileRequest
{
    public List<string> PersonalGoals { get; set; } = new List<string>();
}

public class CreateStudentProfileRequest : CreateProfileRequest
{
    public string? Major { get; set; }
    public string? CareerGoals { get; set; }
}