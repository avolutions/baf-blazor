using Avolutions.Baf.Blazor.Account.Models;
using FluentValidation;

namespace Avolutions.Baf.Blazor.Account.Validators;

public class UserFormValidator : AbstractValidator<UserFormModel>
{
    public UserFormValidator()
    {
        RuleFor(x => x.Firstname)
            .NotEmpty()
            .WithName("field.firstname");
        
        RuleFor(x => x.Lastname)
            .NotEmpty()
            .WithName("field.lastname");
        
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithName("field.username");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithName("field.password");
        
        RuleFor(x => x.PasswordConfirm)
            .NotEmpty()
            .WithName("field.password-confirm")
            .Equal(x => x.Password)
            .WithMessage("validation.password-equal");
    }
}