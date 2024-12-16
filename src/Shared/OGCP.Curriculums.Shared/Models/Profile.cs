namespace OGCP.Curriculums.Shared.Models;

public class Profile
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
    public List<Language> Languages { get; set; } = new List<Language>();
    public List<Education> Educations { get; set; } = new List<Education>();
}
