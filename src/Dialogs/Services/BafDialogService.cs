using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Dialogs.Services;

public abstract class BafDialogService
{
    protected readonly IDialogService DialogService;

    protected BafDialogService(IDialogService dialogService)
    {
        DialogService = dialogService;
    }

    protected async Task<TResult?> ShowAsync<TDialog, TResult>(
        string? title = null,
        DialogParameters<TDialog>? parameters = null,
        DialogOptions? options = null)
        where TDialog : IComponent
        where TResult : class
    {
        var dialog = await DialogService.ShowAsync<TDialog>(
            title, 
            parameters ?? new DialogParameters<TDialog>(), 
            options);

        var result = await dialog.Result;

        if (result is null || result.Canceled)
        {
            return null;
        }

        return result.Data as TResult;
    }
}