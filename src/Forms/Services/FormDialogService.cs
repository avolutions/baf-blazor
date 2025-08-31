using Avolutions.Baf.Blazor.Forms.Components;
using Mapster;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Forms.Services;

public class FormDialogService
{
    private readonly IDialogService _dialogService;
    
    private readonly DialogOptions _options = new()
    {
        BackdropClick = false,
        CloseButton = false,
        CloseOnEscapeKey = false
    };
    
    public FormDialogService(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }
 
    public async Task<T?> ShowAsync<T>(
        string title,
        T model,
        Type formComponentType)
    {
        // Clone the model to avoid modifying the original instance
        var clonedModel = model.Adapt<T>();
        
        var parameters = new DialogParameters
        {
            ["Model"] = clonedModel,
            ["FormComponentType"] = formComponentType
        };
        
        var dialog = await _dialogService.ShowAsync<FormDialog<T>>(title, parameters, _options);
        var result = await dialog.Result;
        
        return result is { Canceled: true } ? default : (T?)result?.Data;
    }
}