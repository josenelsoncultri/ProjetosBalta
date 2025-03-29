namespace Balta.ContentContext;

public class CareerItem
{
    public CareerItem(int order, string title, string description, Course course)
    {
        Order = order;
        Title = title;
        Description = description;
        Course = course;
    }

    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Course Course { get; set; } = null!;
}