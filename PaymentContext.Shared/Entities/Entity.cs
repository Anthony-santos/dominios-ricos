using Flunt.Notifications;

namespace PaymentContext.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Entity()
    {
        id = Guid.NewGuid();
    }

    public Guid id { get; private set; }
}