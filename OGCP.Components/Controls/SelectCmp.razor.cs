using Microsoft.AspNetCore.Components;

namespace OGCP.Components.Controls;

public partial class SelectCmp
{
    [Parameter] public string HtmlId { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public string Name { get; set; }
    [Parameter] public string Placeholder { get; set; } = "Select an option";
    [Parameter] public bool Required { get; set; } = false;
    [Parameter] public string Feedback { get; set; }
    [Parameter] public string FeedbackClass { get; set; }
    [Parameter] public string Value { get; set; }
    [Parameter] public EventCallback<string> ValueChanged { get; set; }
    [Parameter] public List<SelectOption> Options { get; set; }
    [Parameter] public string FormClass { get; set; }
    public void OnInput(string? value)
    {
        if (value != null)
        {
            Value = value;
        }

        ValueChanged.InvokeAsync(Value);
    }
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