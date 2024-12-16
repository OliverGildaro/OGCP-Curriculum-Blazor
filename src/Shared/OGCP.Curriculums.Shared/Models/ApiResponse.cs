namespace OGCP.Curriculums.Shared.Models;

public class ApiResponse
{
    public List<Profile> Result { get; set; } = new List<Profile>();
    public object Errors { get; set; } // Adjust type if errors structure is known
    public DateTime TimeGenerated { get; set; }
}
