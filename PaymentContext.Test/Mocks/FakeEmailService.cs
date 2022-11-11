using PaymentContext.Domain.Service;

namespace PaymentContext.Test.Mocks;

public class FakeEmailService : IEmailService
{
    public void sent(string to, string email, string subject, string body)
    {
        
    }
}