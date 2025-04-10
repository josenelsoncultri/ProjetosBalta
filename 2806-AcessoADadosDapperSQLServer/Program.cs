using Blog.Models;
using Blog.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=NITRO-JN\\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;Trust Server Certificate=True";
using var connection = new SqlConnection(CONNECTION_STRING);
connection.Open();

ReadUsers(connection);
ReadRoles(connection);

connection.Close();

static void ReadUsers(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var users = repository.Get();

    foreach (var user in users)
    {
        Console.WriteLine(user.Name);
    }
}

static void ReadRoles(SqlConnection connection)
{
    var repository = new RoleRepository(connection);
    var roles = repository.Get();

    foreach (var role in roles)
    {
        Console.WriteLine(role.Name);
    }
}