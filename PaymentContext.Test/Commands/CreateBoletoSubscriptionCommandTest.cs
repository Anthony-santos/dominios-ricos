namespace PaymentContext.Test.Commands;

[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]
    public void Should_Return_Error_when_Name_Is_Invalid()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "";
        
        command.Validate();
        Assert.AreEqual(false, command.IsValid);
    }
}