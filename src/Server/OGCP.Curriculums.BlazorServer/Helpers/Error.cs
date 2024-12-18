namespace OGCP.Curriculums.BlazorServer.Helpers;
public class Error
{
    public string PropertyName { get; set; } = string.Empty; // The name of the property (e.g., "GivenName").
    public string Message { get; set; } = string.Empty; // The validation error message.
    public string FeedbackClass { get; set; } = string.Empty; // The CSS class for the feedback (e.g., "text-danger", "text-success").
}
