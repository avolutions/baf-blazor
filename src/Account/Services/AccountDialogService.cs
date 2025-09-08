using Avolutions.Baf.Blazor.Account.Components.Dialogs;
using Avolutions.Baf.Blazor.Account.Resources;
using Avolutions.Baf.Blazor.Snackbar.Services;
using Avolutions.Baf.Core.Identity.Models;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Account.Services;

public class AccountDialogService
{
    private readonly IStringLocalizer<AccountResources> _localizer;
    private readonly IDialogService _dialogService;
    private readonly SnackbarNotificationService _notificationService;
    
    private readonly DialogOptions _options;

    public AccountDialogService(
        IDialogService dialogService,
        SnackbarNotificationService notificationService,
        IStringLocalizer<AccountResources> localizer)
    {
        _dialogService = dialogService;
        _notificationService = notificationService;
        _localizer = localizer;

        _options = new DialogOptions()
        {
            BackdropClick = false,
            CloseOnEscapeKey = true,
            CloseButton = true
        };
    }

    public async Task<bool> ShowLockUserDialogAsync(User user)
    {
        var parameters = new DialogParameters
        {
            ["User"] = user
        };
        
        var dialog = await _dialogService.ShowAsync<LockUserDialog>(
            title: user.IsLocked() ? _localizer["UnlockUser"] : _localizer["LockUser"],
            options: _options,
            parameters: parameters
        );
        var result = await dialog.Result;

        if (result != null && !result.Canceled)
        {
            if (user.IsLocked())
            {
                _notificationService.ShowSuccess(_localizer["LockUserDialog.SuccessfullyLocked", user.GetName()]);
            }
            else
            {
                _notificationService.ShowSuccess(_localizer["LockUserDialog.SuccessfullyUnlocked", user.GetName()]);
            }
            return true;
        }

        return false;
    }

    public async Task<bool> ShowChangePasswordDialogAsync(User user)
    {
        var parameters = new DialogParameters
        {
            ["User"] = user
        };

        var dialog = await _dialogService.ShowAsync<ChangePasswordDialog>(
            title: _localizer["ChangePasswordDialog.Title", user.GetName()],
            options: _options,
            parameters: parameters
        );
        var result = await dialog.Result;

        if (result != null && !result.Canceled)
        {
            _notificationService.ShowSuccess(_localizer["ChangePasswordDialog.SuccessfullyChanged", user.GetName()]);
            return true;
        }

        return false;
    }
}