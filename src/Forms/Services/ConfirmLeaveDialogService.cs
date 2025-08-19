using Avolutions.Baf.Blazor.Forms.Components;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Forms.Services;

public class ConfirmLeaveDialogService
{
    private readonly IDialogService _dialogService;
    
    private readonly DialogOptions _options = new()
    {
        BackdropClick = true,
        CloseButton = true,
        CloseOnEscapeKey = true
    };

    public ConfirmLeaveDialogService(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }
    
    public async Task<DialogResult?> ShowAsync()
    {
        var dialog = await _dialogService.ShowAsync<ConfirmLeaveDialog>(
            title: "confirm-leave-dialog.title",
            options: _options);
        
        return await dialog.Result;
    }
}