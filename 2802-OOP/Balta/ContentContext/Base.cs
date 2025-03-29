using System.Diagnostics.Contracts;
using Balta.NotificationContext;

namespace Balta.ContentContext;

public class Base : Notifiable
{
    public Guid Id { get; set; }

    public Base()
    {
        Id = Guid.NewGuid();
    }
}