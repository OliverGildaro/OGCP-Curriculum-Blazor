using Microsoft.AspNetCore.Components;

namespace OGCP.Curriculums.BlazorServer.Components.controls;
public class ButtonCmpBase : ComponentBase
{
    protected string CssClass { get; set; } = "btn-primary";

    protected void buttonHandleClick()
    {
        CssClass = "btn-secondary";
        Console.WriteLine("Clcik");
        //StateHasChanged(); for indirect state updates
    }
}
