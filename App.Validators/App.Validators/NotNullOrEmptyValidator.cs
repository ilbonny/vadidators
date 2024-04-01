using FluentValidation;
using FluentValidation.Validators;

namespace App.Validators;

public class NotNullValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => "NotNullValidator";

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        return !string.IsNullOrEmpty(value.ToString());
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must not be null or empty.";
}