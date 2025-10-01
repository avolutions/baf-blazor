using Avolutions.Baf.Blazor.Jobs.Components;
using Avolutions.Baf.Blazor.Jobs.Resources;
using Avolutions.Baf.Core.Jobs.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Jobs.Services;

public class ExecuteJobDialogService
{
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<ExecuteJobDialogResources> _localizer;

    public ExecuteJobDialogService(IDialogService dialogService, IStringLocalizer<ExecuteJobDialogResources> localizer)
    {
        _dialogService = dialogService;
        _localizer = localizer;
    }
    
    public async Task<DialogResult?> ShowAsync(IJob job)
    {
        var options = new DialogOptions
        {
            BackdropClick = false,
            CloseButton = true,
            CloseOnEscapeKey = true
        };
        
        var parameters = new DialogParameters
        {
            ["Job"] = job
        };
        
        var dialog = await _dialogService.ShowAsync<ExecuteJobDialog>(
            title: _localizer["Title", job.Name],
            options: options,
            parameters: parameters);
        
        return await dialog.Result;
    }
}