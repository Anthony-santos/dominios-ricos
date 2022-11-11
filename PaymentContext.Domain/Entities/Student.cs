namespace PaymentContext.Domain.Entities;
public class Student : Entity
{
    private IList<Subscription> _subscriptions;
    public Student(Name name, Document document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscriptions = new List<Subscription>();
        
        AddNotifications(name, document, email);
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address? Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get { return _subscriptions.ToArray(); }
    }

    public void AddSubscription(Subscription subscription)
    {
        var hasSubciptionActive = false;
        foreach (var sub in _subscriptions)
        {
            if (sub.Active)
                hasSubciptionActive = true;
        }
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(hasSubciptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
            .AreNotEquals(0, subscription.payments.Count, "Student.Payments", "Essa assinatura não possui pagamentos")
        );
        if(IsValid)
            _subscriptions.Add(subscription);
        
        //Alternativa
        // if(hasSubciptionActive)
        //     AddNotification("Student.Subscription", "Você já tem uma assinatura ativa");
    }
}