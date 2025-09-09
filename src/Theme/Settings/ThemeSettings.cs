using Avolutions.Baf.Core.Settings.Attributes;

namespace Avolutions.Baf.Blazor.Theme.Settings;

[Settings("Theme")]
public class ThemeSettings
{
    public string PrimaryColor { get; set; } = "#3F51B5";
    public string SecondaryColor { get; set; } = "#FF4081";
    public string FontSize { get; set; } = "1rem";
}