using Microsoft.AspNetCore.Components;

namespace OGCP.Components.Components;

public partial class CardCmp
{
    [Parameter] public int Id { get; set; }
    [Parameter] public string ImageSrc { get; set; } = "https://via.placeholder.com/150";
    [Parameter] public string ImageAlt { get; set; } = "Placeholder Image";
    [Parameter] public string Title { get; set; } = "Card title";
    [Parameter] public string Description { get; set; } = "Some quick example text to build on the card title and make up the bulk of the card's content.";
    [Parameter] public string Link { get; set; } = "#";
    [Parameter] public string ButtonText { get; set; } = "Go somewhere";

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void NavigateToDetails()
    {
        this.NavigationManager.NavigateTo($"products/{Id}");
    }
}
