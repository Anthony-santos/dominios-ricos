namespace PaymentContext.Test.ValueObjects;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor
    
    [TestMethod]
    public void Should_Return_Error_when_CNPJ_Is_Invalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsFalse(doc.IsValid);
    }
    
    [TestMethod]
    public void Should_Return_Success_when_CNPJ_Is_Valid()
    {
        var doc = new Document("56360533700203", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    
    [TestMethod]
    public void Should_Return_Error_when_CPF_Is_Invalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsFalse(doc.IsValid);
    }
    
    [DataRow("24723063005")]
    [DataRow("06122680206")]
    [DataRow("83566385425")]
    [TestMethod]
    public void Should_Return_Success_when_CPF_Is_Valid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CNPJ);
        Assert.IsFalse(doc.IsValid);
    }
}