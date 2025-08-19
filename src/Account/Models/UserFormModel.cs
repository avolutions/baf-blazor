using Avolutions.Baf.Core.Identity.Models;

namespace Avolutions.Baf.Blazor.Account.Models;

public class UserFormModel
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string RoleName { get; set; } = SystemRoles.User;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirm { get; set; } = string.Empty;
}