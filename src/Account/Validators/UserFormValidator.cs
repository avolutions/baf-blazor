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
            .WithName(localizer["Field.Firstname"]);
        
        RuleFor(x => x.Lastname)
            .NotEmpty()
            .WithName(localizer["Field.Lastname"]);
        
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithName(localizer["Field.UserName"]);
        
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