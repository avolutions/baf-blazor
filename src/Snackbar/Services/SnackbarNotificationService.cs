using MudBlazor;

namespace Avolutions.Baf.Blazor.Snackbar.Services;

public class SnackbarNotificationService
{
    private readonly ISnackbar _snackbar;
    private readonly string _position = Defaults.Classes.Position.BottomCenter;

    public SnackbarNotificationService(ISnackbar snackbar)
    {
        _snackbar = snackbar;
    }

    public void ShowSuccess(string message)
    {
        _snackbar.Clear();
        _snackbar.Configuration.PositionClass = _position;
        _snackbar.Add(message, Severity.Success);
    }

    public void ShowError(string message)
    {
        _snackbar.Clear();
        _snackbar.Configuration.PositionClass = _position;
        _snackbar.Add(message, Severity.Error);
    }

    public void ShowInfo(string message)
    {
        _snackbar.Clear();
        _snackbar.Configuration.PositionClass = _position;
        _snackbar.Add(message, Severity.Info);
    }
}