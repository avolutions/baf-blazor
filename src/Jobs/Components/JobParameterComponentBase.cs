using Microsoft.AspNetCore.Components;

namespace Avolutions.Baf.Blazor.Jobs.Components;

public abstract class JobParameterComponentBase : ComponentBase
{
    [Parameter] public object Model { get; set; } = default!;
    protected T As<T>() => (T)Model!;
}