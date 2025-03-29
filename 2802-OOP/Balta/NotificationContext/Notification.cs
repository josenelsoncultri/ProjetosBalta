namespace Balta.NotificationContext;

public sealed class Notification
{
    public Notification() { }

    public Notification(string property, string message)
    {
        Property = property;
        Message = message;
    }

    public string Property { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}