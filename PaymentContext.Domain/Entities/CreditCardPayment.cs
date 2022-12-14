namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment{
    public CreditCardPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email, string cardHolderNumber, string cardNumber, string lastTransactionNumber) 
        : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
        CardHolderNumber = cardHolderNumber;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderNumber { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
}