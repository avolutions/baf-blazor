using Avolutions.Baf.Blazor.Account.Components.Dialogs;
using Avolutions.Baf.Blazor.Account.Resources;
using Avolutions.Baf.Blazor.Snackbar.Services;
using Avolutions.Baf.Core.Identity.Abstractions;
using Avolutions.Baf.Core.Identity.Models;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Avolutions.Baf.Blazor.Account.Services;

public class AccountDialogService
{
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<AccountResources> _localizer;
    private readonly IUserDisplayService _userDisplayService;
    private readonly SnackbarNotificationService _notificationService;
    
    private readonly DialogOptions _options;

    public AccountDialogService(
        IDialogService dialogService,
        IStringLocalizer<AccountResources> localizer,
        IUserDisplayService userDisplayService,
        SnackbarNotificationService notificationService)
    {
        _dialogService = dialogService;
        _localizer = localizer;
        _userDisplayService = userDisplayService;
        _notificationService = notificationService;

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
            var userName = _userDisplayService.GetName(user);
            
            if (user.IsLocked())
            {
                _notificationService.ShowSuccess(_localizer["LockUserDialog.SuccessfullyLocked", userName]);
            }
            else
            {
                _notificationService.ShowSuccess(_localizer["LockUserDialog.SuccessfullyUnlocked", userName]);
            }
            return true;
        }

        return false;
    }

    public async Task<bool> ShowChangePasswordDialogAsync(User user)
    {
        var userName = _userDisplayService.GetName(user);
        
        var parameters = new DialogParameters
        {
            ["User"] = user
        };

        var dialog = await _dialogService.ShowAsync<ChangePasswordDialog>(
            title: _localizer["ChangePasswordDialog.Title", userName],
            options: _options,
            parameters: parameters
        );
        var result = await dialog.Result;

        if (result != null && !result.Canceled)
        {
            _notificationService.ShowSuccess(_localizer["ChangePasswordDialog.SuccessfullyChanged", userName]);
            return true;
        }

        return false;
    }
}