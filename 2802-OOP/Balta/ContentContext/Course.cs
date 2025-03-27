using Balta.ContentContext.Enums;

namespace Balta.ContentContext;

public class Course : Content
{
    public Course()
    {
        Modules = new List<Module>();
    }

    public string Tag { get; set; } = string.Empty;
    public IList<Module> Modules { get; set; } = null!;
    public int DurationInMinutes { get; set; }
    public EContentLevel Level { get; set; }
}