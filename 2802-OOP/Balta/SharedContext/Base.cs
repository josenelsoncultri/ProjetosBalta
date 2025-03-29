using Balta.NotificationContext;

namespace Balta.SharedContext;

public class Base : Notifiable
{
    public Guid Id { get; set; }

    public Base()
    {
        Id = Guid.NewGuid();
    }
}