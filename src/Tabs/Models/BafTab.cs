using Avolutions.Baf.Blazor.Tabs.Abstractions;

namespace Avolutions.Baf.Blazor.Tabs.Models;

public abstract class BafTab : IBafTab
{
    private readonly Dictionary<string, object?> _parameters = new();
    
    public abstract string Title { get; }
    public virtual int? BadgeCount { get; protected set; }
    public abstract Type ComponentType { get; }
    
    public virtual IDictionary<string, object?> GetParameters() => _parameters;

    protected void SetParameter(string name, object? value)
    {
        _parameters[name] = value;
    }
    
    public virtual ValueTask OnAddedAsync() => ValueTask.CompletedTask;
    public virtual ValueTask OnActivatedAsync() => ValueTask.CompletedTask;
}