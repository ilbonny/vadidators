using FluentValidation;

namespace App.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Surname).NotEmpty();
        RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name {PropertyName}");
        RuleFor(x => x.Discount).NotEqual(0).ExclusiveBetween(0,10);
        When(x => x.Discount > 0, () =>
        {
            RuleFor(x => x.DiscountDescription).NotEmpty();
        });

        RuleForEach(x => x.Addresses)
            .NotNull().SetValidator(new AddressValidator())
            .WithMessage("Address {CollectionIndex} is required.");

        RuleFor(x=> x.Addresses).ListMustContainFewerThan(1);
    }
}