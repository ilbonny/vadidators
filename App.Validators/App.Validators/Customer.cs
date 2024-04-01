namespace App.Validators;

public class Customer
{
    public int Id { get; set; }
    public string Surname { get; set; } = string.Empty;
    public string Forename { get; set; } = string.Empty;
    public decimal Discount { get; set; } = 0;
    public List<Address> Addresses { get; set; } = new();
    public string DiscountDescription { get; set; } = string.Empty;
}