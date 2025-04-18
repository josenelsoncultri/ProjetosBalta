using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[User]")]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    [Write(false)]
    public List<Role> Roles { get; set; } = [];

    public override string ToString()
    {
        return $"""
        Id: {Id}
        Nome: {Name}
        Email: {Email}
        Bio: {Bio}
        Foto: {Image}
        Slug: {Slug}
        {(Roles.Count != 0 ? "Perfis: " + string.Join(',', Roles.Select(x => x.Name).ToList()) : "")}
        -------------------------------------------------------------------------
        """;
    }
}