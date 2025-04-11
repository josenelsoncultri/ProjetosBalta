using Blog.Models;
using Blog.Repositories;
using Blog.Utils;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=NITRO-JN\\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;Trust Server Certificate=True";
using var connection = new SqlConnection(CONNECTION_STRING);

connection.Open();

var createMethods = new CreateMethods(connection);

createMethods.CreateUser();
ReadUsers(connection);
createMethods.CreateRole();
ReadRoles(connection);
createMethods.CreateTag();
ReadTags(connection);

connection.Close();

static void ReadUsers(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var users = repository.Get();

    foreach (var user in users)
    {
        Console.WriteLine(user.Name);
    }
}

static void ReadRoles(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var roles = repository.Get();

    foreach (var role in roles)
    {
        Console.WriteLine(role.Name);
    }
}

static void ReadTags(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
    var tags = repository.Get();

    foreach (var tag in tags)
    {
        Console.WriteLine(tag.Name);
    }
}