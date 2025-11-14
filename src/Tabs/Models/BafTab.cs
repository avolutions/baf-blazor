using Avolutions.Baf.Blazor.Tabs.Abstractions;

namespace Avolutions.Baf.Blazor.Tabs.Models;

public abstract class BafTab : IBafTab
{
    public virtual string Title { get; set; } = string.Empty;
    public virtual int? BadgeCount { get; set; }
    public abstract Type ComponentType { get; }
    public Dictionary<string, object?> Parameters { get; set; } = [];
    public virtual ValueTask OnAddedAsync() => ValueTask.CompletedTask;
    internal Func<Task>? ReloadHandler { get; set; }
    public Task ReloadAsync()
    {
        return ReloadHandler is null ? Task.CompletedTask : ReloadHandler.Invoke();
    }
}