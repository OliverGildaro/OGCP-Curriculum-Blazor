using Microsoft.AspNetCore.Components;

namespace OGCP.Components;
public class ButtonCmpBase : ComponentBase
{
    [Parameter]
    public string CssClass { get; set; }

    protected void buttonHandleClick()
    {
        CssClass = "btn-secondary";
        Console.WriteLine("Clcik");
        //StateHasChanged(); for indirect state updates
    }
}
