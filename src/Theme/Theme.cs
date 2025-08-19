using MudBlazor;

namespace Avolutions.Baf.Blazor.Theme;

public static class Theme
{
    public static MudTheme Create(ThemeSettings settings) => new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = settings.PrimaryColor,
            Secondary = settings.SecondaryColor
        },
        Typography = new Typography
        {
            Default = new DefaultTypography
            {
                FontSize = settings.FontSize
            }
        }
    };
}