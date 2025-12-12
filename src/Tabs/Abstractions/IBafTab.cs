using MudBlazor;

namespace Avolutions.Baf.Blazor.Tabs.Abstractions;

public interface IBafTab
{
    string Title { get; }
    object? BadgeData { get; }
    Color BadgeColor { get; }
    Task OnActivatedAsync();
    Task OnAddedAsync();
}