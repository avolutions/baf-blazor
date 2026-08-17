namespace Avolutions.Baf.Blazor.Forms.Models;

public sealed record FormDialogResult<T>(FormDialogAction Action, T? Model)
{
    public bool IsSaved => Action == FormDialogAction.Saved;
    public bool IsDeleted => Action == FormDialogAction.Deleted;
    public bool IsCancelled => Action == FormDialogAction.Cancelled;

    public static FormDialogResult<T> Cancelled() => new(FormDialogAction.Cancelled, default);
    public static FormDialogResult<T> Saved(T model) => new(FormDialogAction.Saved, model);
    public static FormDialogResult<T> Deleted(T model) => new(FormDialogAction.Deleted, model);
}