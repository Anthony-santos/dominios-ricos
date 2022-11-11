using PaymentContext.Domain.Handler;
using PaymentContext.Test.Mocks;

namespace PaymentContext.Test.Handler;

[TestClass]
public class SubscriptionHandlerTest
{
    [TestMethod]
    public void Should_Return_Error_when_Document_Exists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Bruce";
        command.LastName = "Wayne";
        command.DocumentNumber = "99999999999";
        command.Email = "bruce@waynecorp.com";
        command.BarCode = "5468681651684656645";
        command.BoletoNumber = "55555555555";
        command.PaymentNumber = "64684646846846";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 10;
        command.TotalPaid = 15;
        command.Payer = "WAYNE CORP";
        command.PayerDocumentNumber = "556454854565";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "bruce@waynecorp.com";
        command.Street = "Rua 1";
        command.Number = "1355";
        command.Neiborhood = "Centro";
        command.City = "Estância";
        command.State = "SE";
        command.Country = "BR";
        command.ZipCode = "49200000";

        handler.Handle(command);
        
        Assert.IsFalse(handler.IsValid);
    }
}