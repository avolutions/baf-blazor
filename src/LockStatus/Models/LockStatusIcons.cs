using Avolutions.Baf.Core.Entity.Models;
using MudBlazor;

namespace Avolutions.Baf.Blazor.LockStatus.Models;

public class LockStatusIcons
{
    public static readonly (Color Color, string Icon) Fallback =
        ( Color.Default, Icons.Material.Filled.Help);
    
    public static readonly (Color Color, string Icon) Info =
        ( Color.Info, Icons.Material.Filled.Info);
    
    public static readonly (Color Color, string Icon) Warning =
        ( Color.Warning, Icons.Material.Filled.Warning);
    
    public static readonly (Color Color, string Icon) Block =
        ( Color.Error, Icons.Material.Filled.Error);
    
    public static (Color Color, string Icon) Get(EntityLockLevel level)
    {
        return level switch
        {
            EntityLockLevel.Info => Info,
            EntityLockLevel.Warning => Warning,
            EntityLockLevel.Block => Block,
            _ => Fallback
        };
    }
}