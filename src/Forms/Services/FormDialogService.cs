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
        Type formComponentType,
        DialogParameters? additionalParameters = null)
    {
        // Clone the model to avoid modifying the original instance
        var localConfig = new TypeAdapterConfig();

        localConfig.Default
            .PreserveReference(true)
            .IgnoreNullValues(true);
        
        var clonedModel = model.Adapt<T>(localConfig);
        
        var parameters = new DialogParameters
        {
            ["Model"] = clonedModel,
            ["FormComponentType"] = formComponentType,
            ["AdditionalParameters"] = additionalParameters
        };
        
        var dialog = await _dialogService.ShowAsync<FormDialog<T>>(title, parameters, _options);
        var result = await dialog.Result;
        
        return result is { Canceled: true } ? default : (T?)result?.Data;
    }
}