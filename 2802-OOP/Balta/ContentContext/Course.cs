namespace Balta.ContentContext;

public class Course : Content
{
    public Course()
    {
        Modules = new List<Module>();
    }

    public string Tag { get; set; } = string.Empty;

    public IList<Module> Modules { get; set; } = null!;
}

public class Module
{
    public Module()
    {
        Lectures = new List<Lecture>();
    }

    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;

    public IList<Lecture> Lectures { get; set; }
}

public class Lecture
{
    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
}