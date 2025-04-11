using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Utils;

public class UpdateMethods(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;

    public void UpdateUser()
    {
        var repository = new Repository<User>(_connection);

        var user = repository.Get().Last();
        user.Name = "José Nelson Cultri Atualizado";

        repository.Update(user);
    }

    public void UpdateRole()
    { 
        var repository = new Repository<Role>(_connection);

        var role = repository.Get().Last();
        role.Name = "Administrador Atualizado";

        repository.Update(role);
    }

    public void UpdateTag()
    { 
        var repository = new Repository<Tag>(_connection);

        var tag = repository.Get().Last();
        tag.Name = "Blazor / MAUI Atualizado";

        repository.Update(tag);
    }
}
