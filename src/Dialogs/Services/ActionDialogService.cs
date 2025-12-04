using Avolutions.Baf.Blazor.Dialogs.Components;
using Avolutions.Baf.Blazor.Dialogs.Resources;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Dialogs.Services;

public class ActionDialogService
{
    private readonly IDialogService _dialogService;

    public ActionDialogService(IDialogService dialogService, IStringLocalizer<DialogResources> localizer)
    {
        _dialogService = dialogService;
    }
    
    public async Task<DialogResult?> ShowAsync(string title, string contentText, string actionButtonText, Color actionButtonColor = Color.Primary)
    {
        var options = new DialogOptions
        {
            BackdropClick = true,
            CloseButton = true,
            CloseOnEscapeKey = true
        };
        
        var parameters = new DialogParameters<ActionDialog>
        {
            { x => x.ContentText, contentText },
            { x => x.ActionButtonText, actionButtonText },
            { x => x.ActionButtonColor, actionButtonColor }
        };
        
        var dialog = await _dialogService.ShowAsync<ActionDialog>(
            title: title,
            options: options,
            parameters: parameters);
        return await dialog.Result;
    }
}