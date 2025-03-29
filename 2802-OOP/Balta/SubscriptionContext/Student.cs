using Balta.NotificationContext;
using Balta.SharedContext;

namespace Balta.SubscriptionContext;

public class Student : Base
{
    public User User { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public IList<Subscription> Subscriptions { get; set; } = [];

    public bool IsPremium => !Subscriptions.Any(x => x.IsInactive);

    public void CreateSubscription(Subscription subscription)
    {
        if (IsPremium)
        {
            AddNotification(new Notification("Premium", "O aluno já tem uma assinatura ativa"));
            return;
        }

        Subscriptions.Add(subscription);
    }
}