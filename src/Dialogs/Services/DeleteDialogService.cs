using Avolutions.Baf.Blazor.Dialogs.Components;
using Avolutions.Baf.Blazor.Dialogs.Resources;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Dialogs.Services;

public class DeleteDialogService
{
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<DialogResources> _localizer;

    public DeleteDialogService(IDialogService dialogService, IStringLocalizer<DialogResources> localizer)
    {
        _dialogService = dialogService;
        _localizer = localizer;
    }
    
    public async Task<DialogResult?> ShowAsync(string? title = null, string? content = null)
    {
        var options = new DialogOptions
        {
            BackdropClick = true,
            CloseButton = true,
            CloseOnEscapeKey = true
        };
        
        var parameters = new DialogParameters
        {
            ["Content"] = content ?? _localizer["DeleteDialog.Content"]
        };
        
        var dialog = await _dialogService.ShowAsync<DeleteDialog>(
            title: title ?? _localizer["DeleteDialog.Title"],
            options: options,
            parameters: parameters);
        return await dialog.Result;
    }
}