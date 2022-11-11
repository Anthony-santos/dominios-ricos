namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street, string number, string neiborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neiborhood = neiborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterOrEqualsThan(Street, 3, "Name.FirstName", "Nome deve contrar pelo menos 3 caracteres")
        );
    }
    
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neiborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}