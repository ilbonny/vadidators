
using App.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

var ci = new CultureInfo("en-EN");
//Thread.CurrentThread.CurrentCulture = ci;
Thread.CurrentThread.CurrentUICulture = ci;

Console.WriteLine(CultureInfo.CurrentUICulture);

var customer = new Customer
{
    Id = 1,
    Forename = "",
    Surname = "",
    Discount = 12,
    Addresses = new List<Address>
    {
        new Address
        {
            City = "",
            Country = "DE",
            PostalCode = "2",
            Region = "Region"
        }
    }
};

var serviceProvider = new ServiceCollection()
    .AddValidatorsFromAssemblyContaining<CustomerValidator>()
    .AddSingleton<IService, Service>()
    .BuildServiceProvider();


var service = serviceProvider.GetService<IService>();
service.Execute(customer);

Console.ReadLine();
