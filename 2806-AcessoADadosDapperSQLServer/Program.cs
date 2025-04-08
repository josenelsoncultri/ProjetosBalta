using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=NITRO-JN\\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;Trust Server Certificate=True";

ReadUsers();

static void ReadUsers()
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var users = connection.GetAll<User>();

    foreach (var user in users)
    {
        Console.WriteLine(user.Name);
    }
}