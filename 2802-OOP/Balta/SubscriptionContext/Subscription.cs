using Balta.SharedContext;

namespace Balta.SubscriptionContext;

public class Subscription : Base
{
    public Plan Plan { get; set; } = null!;
    public DateTime? EndDate { get; set; }
    public bool IsInactive => EndDate <= DateTime.Now;
}