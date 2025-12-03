using MudBlazor;

namespace Avolutions.Baf.Blazor.DataTable.Models;

public class RowAction<T>
{
    public Color Color { get; set; } = Color.Primary;
    public Func<T, Color>? ColorFunc { get; set; }
    public bool Disabled { get; set; }
    public Func<T, bool>? DisabledFunc { get; set; }
    public string? Icon { get; set; }
    public Func<T, string>? IconFunc { get; set; }
    public Size Size { get; set; } = Size.Medium;
    public Func<T, Size>? SizeFunc { get; set; }
    public string? Text { get; set; }
    public Func<T, string>? TextFunc { get; set; }
    public bool Visible { get; set; } = true;
    public Func<T, bool>? VisibleFunc { get; set; }
    public Func<T, Task>? OnClick { get; set; }

    public Task InvokeAsync(T item) =>
        OnClick?.Invoke(item) ?? Task.CompletedTask;
    
    public Color GetColor(T item) => ColorFunc?.Invoke(item) ?? Color;
    public string GetIcon(T item) => IconFunc?.Invoke(item) ?? Icon ?? "";
    public Size GetSize(T item) => SizeFunc?.Invoke(item) ?? Size;
    public string GetText(T item) => TextFunc?.Invoke(item) ?? Text ?? "";
    public bool IsDisabled(T item) => DisabledFunc?.Invoke(item) ?? Disabled;
    public bool IsVisible(T item) => VisibleFunc?.Invoke(item) ?? Visible;
}