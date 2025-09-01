using Avolutions.Baf.Blazor.Forms.Components;
using Avolutions.Baf.Blazor.Forms.Resources;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Forms.Services;

public class ConfirmLeaveDialogService
{
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<FormResources> _localizer;
    
    private readonly DialogOptions _options = new()
    {
        BackdropClick = true,
        CloseButton = true,
        CloseOnEscapeKey = true
    };

    public ConfirmLeaveDialogService(IDialogService dialogService, IStringLocalizer<FormResources> localizer)
    {
        _dialogService = dialogService;
        _localizer = localizer;
    }
    
    public async Task<DialogResult?> ShowAsync()
    {
        var dialog = await _dialogService.ShowAsync<ConfirmLeaveDialog>(
            title: _localizer["confirm-leave-dialog.title"],
            options: _options);
        
        return await dialog.Result;
    }
}