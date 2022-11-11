using PaymentContext.Domain.Repositories;

namespace PaymentContext.Test.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public bool DocumentExists(string document)
    {
        if (document == "99999999999")
            return true;
        return false;
    }

    public bool EmailExists(string email)
    {
        if (email == "bruce@waynecorp.com")
            return true;
        return false;
    }

    public void CreateSubscription(Student student)
    {
        
    }
}