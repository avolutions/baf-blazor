using FluentValidation;

namespace Avolutions.Baf.Blazor.Forms.Helpers;

public static class FluentValidatorHelper
{
    public static Func<object, string, Task<IEnumerable<string>>> CreateValidateValue<T>(IValidator<T>? validator)
    {
        return async (model, propertyName) =>
        {
            if (validator is null || model is not T typedModel)
                return [];

            var result = await validator.ValidateAsync(
                ValidationContext<T>.CreateWithOptions(typedModel, x => x.IncludeProperties(propertyName)));

            return result.IsValid
                ? []
                : result.Errors.Select(e => e.ErrorMessage);
        };
    }
}