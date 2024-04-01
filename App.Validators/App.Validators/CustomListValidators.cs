using FluentValidation;

namespace App.Validators;

public static class CustomListValidators
{
    public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(
        this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
    {
        return ruleBuilder.Must(list => list.Count < num).WithMessage("{PropertyName} must contain fewer than items.");
    }
}