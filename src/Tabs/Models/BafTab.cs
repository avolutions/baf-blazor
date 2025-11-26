using Avolutions.Baf.Blazor.Tabs.Abstractions;
using Avolutions.Baf.Blazor.Tabs.Components;
using Microsoft.AspNetCore.Components;

namespace Avolutions.Baf.Blazor.Tabs.Models;

public abstract class BafTab : ComponentBase, IBafTab
{
    [CascadingParameter]
    private BafTabs? Parent { get; set; }
    
    public abstract string Title { get; }
    
    public virtual object? BadgeData => null;
    
    protected override void OnInitialized()
    {
        Parent?.RegisterTab(Title, BadgeData, BuildRenderTree, this);
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Update badge data after async initialization
            Parent?.UpdateBadgeData(this, BadgeData);
        }
    }
    
    public virtual Task OnActivatedAsync()
    {
        return Task.CompletedTask;
    }
}