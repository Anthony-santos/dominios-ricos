namespace PaymentContext.Test.Entities;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("83566385425", EDocumentType.CPF);
        _address = new Address("Rua 1", "1350", "Bairro Complicado", "Gotham", "SE", "BR", "49200000");
        _email = new Email("batman@dc.com");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }
    
    [TestMethod]
    public void Should_Return_Error_When_Had_Active_Subscription()
    {
        var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
        
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
        
        Assert.IsFalse(_student.IsValid);
    }
    
    [TestMethod]
    public void Should_Return_Error_When_Subscription_Has_No_Payment()
    {
        _student.AddSubscription(_subscription);
        
        Assert.IsFalse(_student.IsValid);
    }
    
    [TestMethod]
    public void Should_Return_Success_When_Add_Subscription()
    {
        var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
        
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        
        Assert.IsTrue(_student.IsValid);
    }
}