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
            .WithName(localizer["Field.Password"]);
        
        RuleFor(x => x.PasswordConfirm)
            .NotEmpty()
            .WithName(localizer["Field.PasswordConfirm"])
            .Equal(x => x.Password)
            .WithMessage(localizer["Validation.PasswordEqual"]);
    }
}