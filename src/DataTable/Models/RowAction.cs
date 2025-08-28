using MudBlazor;

namespace Avolutions.Baf.Blazor.DataTable.Models;

public class RowAction<T>
{
    public Variant Variant { get; set; } = Variant.Filled;
    public Color Color { get; set; } = Color.Primary;
    public Func<T, Color>? ColorFunc { get; set; }
    public string? Icon { get; set; }
    public Func<T, string>? IconFunc { get; set; }
    public string? Text { get; set; }
    public Func<T, string>? TextFunc { get; set; }
    public Func<T, Task>? OnClick { get; set; }

    public Task InvokeAsync(T item) =>
        OnClick?.Invoke(item) ?? Task.CompletedTask;
    
    public string GetText(T item) => TextFunc?.Invoke(item) ?? Text ?? "";
    public string GetIcon(T item) => IconFunc?.Invoke(item) ?? Icon ?? "";
    public Color GetColor(T item) => ColorFunc?.Invoke(item) ?? Color;
}