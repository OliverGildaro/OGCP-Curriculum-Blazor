namespace OGCP.Curriculums.BlazorServer.Helpers;
public class ErrorManager
{
    private readonly Dictionary<string, Error> _errors = new();

    // Add or update an error for a specific property
    public void SetError(string propertyName, string message, string feedbackClass)
    {
        _errors[propertyName] = new Error
        {
            PropertyName = propertyName,
            Message = message,
            FeedbackClass = feedbackClass
        };
    }

    // Remove the error for a specific property
    public void ClearError(string propertyName)
    {
        if (_errors.ContainsKey(propertyName))
        {
            _errors.Remove(propertyName);
        }
    }

    // Get the error message for a specific property
    public string GetMessage(string propertyName)
    {
        return _errors.ContainsKey(propertyName) ? _errors[propertyName].Message : string.Empty;
    }

    // Get the feedback class for a specific property
    public string GetFeedbackClass(string propertyName)
    {
        return _errors.ContainsKey(propertyName) ? _errors[propertyName].FeedbackClass : string.Empty;
    }

    // Check if there are any errors
    public bool HasErrors => _errors.Count > 0;

    // Clear all errors
    public void ClearAll()
    {
        _errors.Clear();
    }
}
