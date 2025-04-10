using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;

    public IEnumerable<User> Get() => _connection.GetAll<User>();

    public User Get(int id) => _connection.Get<User>(id);

    public void Insert(User user) => _connection.Insert(user);   
    public void Update(User user) => _connection.Update(user);

    public void Remove(int id)
    {
        var user = _connection.Get<User>(id);
        _connection.Delete(user);
    }
}