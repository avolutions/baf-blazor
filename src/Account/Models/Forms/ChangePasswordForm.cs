namespace NetzwerkStein.Features.Framework.UserManagement.Models.Forms;

public class ChangePasswordForm
{
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirm { get; set; } = string.Empty;
}