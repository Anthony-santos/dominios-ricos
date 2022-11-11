using System.Security.Cryptography.X509Certificates;

namespace PaymentContext.Domain.Service;

public interface IEmailService
{
    void sent(string to, string email, string subject, string body);
}