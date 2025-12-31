using Avolutions.Baf.Blazor.Dialogs.Resources;
using Avolutions.Baf.Core.Resources;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Dialogs.Services;

public class DeleteDialogService : ActionDialogService
{
    private readonly IStringLocalizer<DialogResources> _localizer;
    private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

    public DeleteDialogService(
        IDialogService dialogService,
        IStringLocalizer<DialogResources> localizer,
        IStringLocalizer<SharedResources> sharedLocalizer)
        : base(dialogService, localizer)
    {
        _localizer = localizer;
        _sharedLocalizer = sharedLocalizer;
    }

    public async Task<DialogResult?> ShowAsync(string? title = null, string? content = null)
    {
        return await base.ShowAsync(
            title: title ?? _localizer["DeleteDialog.Title"],
            contentText: content ?? _localizer["DeleteDialog.Content"],
            actionButtonText: _sharedLocalizer["Button.Delete"],
            actionButtonColor: Color.Error);
    }
}
