namespace Avolutions.Baf.Blazor.Tabs.Abstractions;

public interface IBafTab
{
    string Title { get; set; }
    int? BadgeCount { get; set; }
    Type ComponentType { get; }
    Dictionary<string, object?> Parameters { get; set;  }
    
    Task ReloadAsync();
    ValueTask OnAddedAsync();
}