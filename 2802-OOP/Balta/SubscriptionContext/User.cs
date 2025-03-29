using System.Threading.Channels;
using Balta.SharedContext;

namespace Balta.SubscriptionContext;

public class User : Base
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}