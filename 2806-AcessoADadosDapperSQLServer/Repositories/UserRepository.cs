using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository
{
    private SqlConnection _connection = new SqlConnection("");
    public IEnumerable<User> Get()
    {
        return _connection.GetAll<User>();
    }

    public User Get(int id)
    {
        return _connection.Get<User>(id);
    }

    public void Insert(User user)
    {
        _connection.Insert<User>(user);   
    }
}