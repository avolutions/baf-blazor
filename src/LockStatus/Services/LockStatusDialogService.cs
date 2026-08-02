using Avolutions.Baf.Blazor.Jobs.Resources;
using Avolutions.Baf.Blazor.LockStatus.Components;
using Avolutions.Baf.Core.Entity.Abstractions;
using Avolutions.Baf.Core.Entity.Models;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.LockStatus.Services;

public class LockStatusDialogService
{
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<ExecuteJobDialogResources> _localizer;

    public LockStatusDialogService(IDialogService dialogService, IStringLocalizer<ExecuteJobDialogResources> localizer)
    {
        _dialogService = dialogService;
        _localizer = localizer;
    }
    
    public async Task<DialogResult?> ShowAsync(ILockable entity, EntityLockLevel level)
    {
        var options = new DialogOptions
        {
            BackdropClick = false,
            CloseButton = true,
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true
        };
        
        var parameters = new DialogParameters<LockStatusDialog>
        {
            { x => x.Entity, entity },
            { x => x.Level, level }
        };
        
        var dialog = await _dialogService.ShowAsync<LockStatusDialog>(
            title: null,
            options: options,
            parameters: parameters);
        
        return await dialog.Result;
    }
    
    public async Task ShowBlockedAsync(string entityName, EntityLockStatus status)
    {
        var parameters = new DialogParameters<LockStatusBlockedDialog>
        {
            { x => x.EntityName, entityName },
            { x => x.Status, status }
        };

        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Small,
            FullWidth = true
        };

        var dialog = await _dialogService.ShowAsync<LockStatusBlockedDialog>(null, parameters, options);

        await dialog.Result;
    }
}