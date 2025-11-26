namespace Avolutions.Baf.Blazor.Tabs.Abstractions;

public interface IBafTab
{
    string Title { get; }
    object? BadgeData { get; }
    Task OnActivatedAsync();
}