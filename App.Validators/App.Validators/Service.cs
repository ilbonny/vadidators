using FluentValidation;

namespace App.Validators;

public interface IService
{
    void Execute(Customer customer);
}

public class Service : IService
{
    private readonly IValidator<Customer> _validator;

    public Service(IValidator<Customer> validator)
    {
        _validator = validator;
    }

    public void Execute(Customer customer)
    {
        var results = _validator.Validate(customer);

        Console.WriteLine(results.ToString());
    }
}