using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;

    public IEnumerable<Role> Get() => _connection.GetAll<Role>();

    public Role Get(int id) => _connection.Get<Role>(id);

    public void Insert(Role role) => _connection.Insert(role);  
    public void Update(Role role) => _connection.Update(role);

    public void Remove(int id)
    {
        var Role = _connection.Get<Role>(id);
        _connection.Delete(Role);
    }
}