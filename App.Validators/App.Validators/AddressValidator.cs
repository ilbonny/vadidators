using FluentValidation;

namespace App.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.City).NotNull();
        RuleFor(a => a.Region).NotEmpty();
        RuleFor(a => a.Country).Length(2).Custom((x, context) =>
        {
            var regions = new[] { "IT", "ES" };

            if(!regions.Contains(x))
                context.AddFailure($"The countries not contains {x}");
        });
        RuleFor(a => a.PostalCode).Length(5).When(a => !string.IsNullOrEmpty(a.PostalCode));
    }    
}