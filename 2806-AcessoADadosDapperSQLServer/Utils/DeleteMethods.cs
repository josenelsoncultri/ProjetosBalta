using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Utils;

public class DeleteMethods(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;

    public void DeleteUser()
    {
        var repository = new Repository<User>(_connection);
        var user = repository.Get().First();
        repository.Delete(user);
    }

    public void DeleteRole()
    {
        var repository = new Repository<Role>(_connection);
        var role = repository.Get().First();
        repository.Delete(role);
    }

    public void DeleteTag()
    {
        var repository = new Repository<Tag>(_connection);
        var tag = repository.Get().First();
        repository.Delete(tag);
    }
}
