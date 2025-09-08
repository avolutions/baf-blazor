using Avolutions.Baf.Core.Identity.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using NetzwerkStein.Features.Framework.UserManagement.Models.Forms;

namespace Avolutions.Baf.Blazor.Account.Validators;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordForm>
{
    public ChangePasswordValidator(IStringLocalizer<IdentityResources> localizer)
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithName(localizer["field.password"]);
        
        RuleFor(x => x.PasswordConfirm)
            .NotEmpty()
            .WithName(localizer["field.password-confirm"])
            .Equal(x => x.Password)
            .WithMessage(localizer["validation.password-equal"]);
    }
}