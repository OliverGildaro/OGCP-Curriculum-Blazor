using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace OGCP.Components.Controls;
public partial class ButtonCmp
{
    [Parameter]
    public string HtmlId { get; set; }
    [Parameter]
    public string CssClass { get; set; }
    [Parameter]
    public string TypeBtn { get; set; }
    [Parameter]
    public string Disabled { get; set; }
    [Parameter]
    public string Label{ get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> HandleClick { get; set; }
}
