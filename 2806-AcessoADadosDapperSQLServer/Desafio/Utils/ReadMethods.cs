using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Utils;

public class ReadMethods(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;

    public void ReadUsers()
    {
        var repository = new UserRepository(_connection);
        var users = repository.GetWithRoles();

        foreach (var user in users)
        {
            Console.WriteLine(user.Name);

            foreach (var role in user.Roles)
            {
                Console.WriteLine($"- {role.Name}");
            }
        }
    }

    public void ReadRoles()
    {
        var repository = new Repository<Role>(_connection);
        var roles = repository.Get();

        foreach (var role in roles)
        {
            Console.WriteLine(role.Name);
        }
    }

    public void ReadTags()
    {
        var repository = new Repository<Tag>(_connection);
        var tags = repository.Get();

        foreach (var tag in tags)
        {
            Console.WriteLine(tag.Name);
        }
    }
}
