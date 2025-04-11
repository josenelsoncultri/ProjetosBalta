using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Utils;

public class CreateMethods(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;
    public void CreateUser()
    {
        var repository = new Repository<User>(_connection);

        var user = new User()
        {
            Id = 0,
            Name = "José Nelson Cultri Teste",
            Email = "josefcultri_teste12345@hotmail.com",
            Image = "image.gif",
            PasswordHash = "hash",
            Bio = "Desenvolvedor por profissão, poeta nas horas vagas, jogador de Guitar Hero pra sempre!",
            Slug = "jose-nelson-cultri"
        };

        repository.Create(user);
    }

    public void CreateRole()
    { 
        var repository = new Repository<Role>(_connection);

        var role = new Role()
        {
            Id = 0,
            Name = "Professor",
            Slug = "teacher"
        };

        repository.Create(role);
    }

    public void CreateTag()
    {
        var repository = new Repository<Tag>(_connection);

        var tag = new Tag()
        {
            Id = 0,
            Name = "Blazor / MAUI",
            Slug = "blazor-maui"
        };

        repository.Create(tag);
    }
}
