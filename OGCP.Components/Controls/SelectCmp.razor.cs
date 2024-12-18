using Microsoft.AspNetCore.Components;

namespace OGCP.Components.Controls;

public partial class SelectCmp
{
    [Parameter] public string HtmlId { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public string Placeholder { get; set; } = "Select an option";
    [Parameter] public bool Required { get; set; } = false;
    [Parameter] public string Feedback { get; set; }
    [Parameter] public string FeedbackClassName { get; set; }
    [Parameter] public string Value { get; set; }
    [Parameter] public EventCallback<string> ValueChanged { get; set; }
    [Parameter] public List<SelectOption> Options { get; set; }

    private string CssClass => $"form-control {ControlClassName}";

    private string ControlClassName =>
        !string.IsNullOrEmpty(Feedback) ? (IsSuccess ? "is-valid" : "is-invalid") : "";

    [Parameter] public bool IsSuccess { get; set; }
}

public class SelectOption
{
    public string Value { get; set; }
    public string Label { get; set; }
}

public enum ProfileRequests
{
    CreateGeneral = 1,
    CreateQualified,
    CreateStudent,
}