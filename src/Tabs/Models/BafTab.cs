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
    
    protected override async Task OnInitializedAsync()
    {
        if (Parent != null)
        {
            await Parent.RegisterTabAsync(Title, BuildRenderTree, this);
        }
    }
    
    public virtual Task OnAddedAsync()
    {
        return Task.CompletedTask;
    }
    
    public virtual Task OnActivatedAsync()
    {
        return Task.CompletedTask;
    }
}