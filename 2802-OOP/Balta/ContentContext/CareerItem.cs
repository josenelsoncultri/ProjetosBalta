namespace Balta.ContentContext;

public class CareerItem
{
    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Course Course { get; set; } = null!;
}