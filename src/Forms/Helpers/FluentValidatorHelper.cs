using FluentValidation;
using FluentValidation.Internal;

namespace Avolutions.Baf.Blazor.Forms.Helpers;

public static class FluentValidatorHelper
{
    private sealed class AndSelector(params IValidatorSelector[] selectors) : IValidatorSelector
    {
        public bool CanExecute(IValidationRule rule, string propertyPath, IValidationContext context)
            => selectors.All(s => s.CanExecute(rule, propertyPath, context));
    }
    
    public static Func<object, string, Task<IEnumerable<string>>> CreateValidateValue<T>(IValidator<T>? validator)
    {
        return async (model, propertyName) =>
        {
            if (validator is null || model is not T typed || string.IsNullOrWhiteSpace(propertyName))
            {
                return [];
            }
            
            var memberSel  = ValidatorOptions.Global.ValidatorSelectors
                .MemberNameValidatorSelectorFactory([propertyName]);
            var defaultSel = ValidatorOptions.Global.ValidatorSelectors
                .RulesetValidatorSelectorFactory(["default"]);
            
            var context = new ValidationContext<T>(typed, new PropertyChain(),
                new AndSelector(memberSel, defaultSel));

            var result = await validator.ValidateAsync(context);

            return result.IsValid ? [] : result.Errors.Select(e => e.ErrorMessage);
        };
    }
}