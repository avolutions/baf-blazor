using Avolutions.Baf.Blazor.Forms.Components;
using Avolutions.Baf.Blazor.Forms.Models;
using FluentValidation;
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
        CloseOnEscapeKey = false,
    };
    
    public FormDialogService(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }
 
    public async Task<T?> ShowAsync<T>(
        string title,
        T model,
        Type formComponentType,
        IValidator<T>? validator = null,
        DialogParameters? additionalParameters = null,
        DefaultFocus defaultFocus = DefaultFocus.FirstChild)
    {
        var result = await OpenDialogAsync(title, model, formComponentType, validator, additionalParameters, defaultFocus, false);

        return result.IsSaved ? result.Model : default;
    }
    
    public async Task<FormDialogResult<T>> ShowWithDeleteButtonAsync<T>(
        string title,
        T model,
        Type formComponentType,
        IValidator<T>? validator = null,
        DialogParameters? additionalParameters = null,
        DefaultFocus defaultFocus = DefaultFocus.FirstChild)
    {
        return await OpenDialogAsync(title, model, formComponentType, validator, additionalParameters, defaultFocus, true);
    }
    
    private async Task<FormDialogResult<T>> OpenDialogAsync<T>(
        string title,
        T model,
        Type formComponentType,
        IValidator<T>? validator,
        DialogParameters? additionalParameters,
        DefaultFocus defaultFocus,
        bool showDeleteButton)
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
            ["Validator"] = validator,
            ["AdditionalParameters"] = additionalParameters,
            ["DefaultFocus"] = defaultFocus,
            ["ShowDeleteButton"] = showDeleteButton
        };
        
        var dialog = await _dialogService.ShowAsync<FormDialog<T>>(title, parameters, _options);
        var result = await dialog.Result;
        
        if (result is null || result.Canceled || result.Data is not FormDialogResult<T> formResult)
        {
            return FormDialogResult<T>.Cancelled();
        }

        return formResult;
    }
}