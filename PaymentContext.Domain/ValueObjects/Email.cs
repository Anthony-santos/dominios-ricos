namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(Address, "Email.Address", "E-mail invalido"));
    }

    public string Address { get; private set; }
}