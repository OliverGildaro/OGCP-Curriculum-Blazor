using Microsoft.AspNetCore.Components;

namespace OGCP.Components.Controls;

public partial class SelectCmp
{
    [Parameter] public string HtmlId { get; set; }
    [Parameter] public string Name { get; set; }
    [Parameter] public string Label { get; set; }
    [Parameter] public bool Required { get; set; } = false;
    [Parameter] public string PlaceHolder { get; set; }
    [Parameter] public string Value { get; set; }
    [Parameter] public List<SelectOption> Options { get; set; }
    [Parameter] public string Feedback { get; set; }
    [Parameter] public bool IsSuccess { get; set; }
    [Parameter] public EventCallback<string> OnValueChange { get; set; }

    private string ControlClassName =>
        !string.IsNullOrEmpty(Feedback) ? (IsSuccess ? "is-valid" : "is-invalid") : "";

    private string FeedbackClassName =>
        !string.IsNullOrEmpty(Feedback) ? (IsSuccess ? "" : "") : "";

    private async Task HandleChange(ChangeEventArgs e)
    {
        if (e.Value is not null)
        {
            Value = e.Value.ToString(); // Actualiza el valor localmente
            await OnValueChange.InvokeAsync(Value); // Invoca el callback al componente padre
        }
    }
}

public class SelectOption
{
    public ProfileRequests Value { get; set; }
    public string Label { get; set; }
}

public enum ProfileRequests
{
    CreateGeneral = 1,
    CreateQualified,
    CreateStudent,
}