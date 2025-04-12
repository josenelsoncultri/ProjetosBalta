using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Tag]")]
public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    [Write(false)]
    public List<Post> Posts { get; set; } = [];

    public override string ToString()
    {
        return $"""
        Id: {Id} - Name: {Name} - Slug: {Slug}
        """;
    }
}