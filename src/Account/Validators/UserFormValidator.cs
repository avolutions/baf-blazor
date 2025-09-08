using Avolutions.Baf.Blazor.Account.Models.Forms;
using Avolutions.Baf.Core.Identity.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Avolutions.Baf.Blazor.Account.Validators;

public class UserFormValidator : AbstractValidator<UserFormModel>
{
    public UserFormValidator(IStringLocalizer<IdentityResources> localizer)
    {
        RuleFor(x => x.Firstname)
            .NotEmpty()
            .WithName(localizer["field.firstname"]);
        
        RuleFor(x => x.Lastname)
            .NotEmpty()
            .WithName(localizer["field.lastname"]);
        
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithName(localizer["field.username"]);
        
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