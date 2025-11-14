namespace Avolutions.Baf.Blazor.Tabs.Models;

public class BafTabPanel(Type tabType, object[]? args = null)
{
    public Type TabType { get; } = tabType ?? throw new ArgumentNullException(nameof(tabType));
    public object[]? Args { get; } = args;
}

public abstract class BafTabPanel<TTab>(params object[] args) : BafTabPanel(typeof(TTab), args)
    where TTab : class;