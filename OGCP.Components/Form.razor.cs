using Microsoft.AspNetCore.Components;

namespace OGCP.Components;

public partial class Form
{
    private enum Status
    {
        Idle,
        Submitted,
        Submitting,
        Completed
    }

    private Status CurrentStatus { get; set; } = Status.Idle;
    private Exception? SaveError { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback<EventArgs> OnSubmit { get; set; }

    private async Task HandleSubmit()
    {
        CurrentStatus = Status.Submitting;
        SaveError = null;

        try
        {
            await OnSubmit.InvokeAsync(EventArgs.Empty);
            CurrentStatus = Status.Completed;
        }
        catch (Exception ex)
        {
            SaveError = ex;
        }
    }
}
