using Avolutions.Baf.Blazor.Theme.Resources;
using Avolutions.Baf.Blazor.Theme.Settings;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Avolutions.Baf.Blazor.Theme.Validators;

public class ThemeSettingsValidator : AbstractValidator<ThemeSettings>
{
    public ThemeSettingsValidator(IStringLocalizer<ThemeResources> localizer)
    {
        RuleFor(x => x.PrimaryColor)
            .NotEmpty()
            .WithName(localizer["PrimaryColor"]);
        
        RuleFor(x => x.SecondaryColor)
            .NotEmpty()
            .WithName(localizer["SecondaryColor"]);
        
        RuleFor(x => x.FontSize)
            .NotEmpty()
            .Matches(@"^\d+(\.\d+)?(px|em|rem|%)$")
            .WithMessage(localizer["FontSize.Invalid"])
            .WithName(localizer["FontSize"]);
    }
}