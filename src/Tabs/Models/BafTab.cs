using Avolutions.Baf.Blazor.Tabs.Abstractions;
using Avolutions.Baf.Blazor.Tabs.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Tabs.Models;

public abstract class BafTab : ComponentBase, IBafTab
{
    [CascadingParameter]
    private BafTabs? Parent { get; set; }
    
    public abstract string Title { get; }
    
    public virtual object? BadgeData => null;
    public virtual Color BadgeColor => Color.Primary;
    
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
    
    protected void NotifyParentStateChanged()
    {
        Parent?.NotifyStateChanged();
    }
}