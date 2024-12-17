using Microsoft.AspNetCore.Components;

namespace OGCP.Components.Controls;

public partial class InputField
{
    [Parameter] public string HtmlId { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public string Name { get; set; }
    [Parameter] public string FieldType { get; set; } = "text";
    [Parameter] public string Placeholder { get; set; }
    [Parameter] public string Value { get; set; }
    [Parameter] public string FormClass { get; set; }
    [Parameter] public string FeedbackClass { get; set; }
    [Parameter] public string Feedback { get; set; }

    public void HandleChange(ChangeEventArgs e)
    {
    }
}
