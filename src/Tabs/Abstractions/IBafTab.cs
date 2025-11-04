namespace Avolutions.Baf.Blazor.Tabs.Abstractions;

public interface IBafTab
{
    string Title { get; }
    int? BadgeCount { get; }
    Type ComponentType { get; }
    
    IDictionary<string, object?> GetParameters();
    ValueTask OnAddedAsync();
    ValueTask OnActivatedAsync();
}