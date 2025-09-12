using Avolutions.Baf.Blazor.Audit.Components;
using Avolutions.Baf.Blazor.Audit.Resources;
using Avolutions.Baf.Core.Entity.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Audit.Services;

public class AuditInfoDialogService
{
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<AuditResources> _localizer;

    public AuditInfoDialogService(IDialogService dialogService, IStringLocalizer<AuditResources> localizer)
    {
        _dialogService = dialogService;
        _localizer = localizer;
    }

    public async Task<DialogResult?> ShowAsync<T>(T entity)
        where T : ITrackable
    {
        var options = new DialogOptions
        {
            BackdropClick = true,
            CloseButton = true,
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.ExtraSmall,
            FullWidth = true
        };
        
        var parameters = new DialogParameters
        {
            ["Entity"] = entity,
        };

        var dialog = await _dialogService.ShowAsync<AuditInfoDialog<T>>(
            _localizer["AuditInfo.Title"],
            parameters,
            options
        );
        return await dialog.Result;
    }
}