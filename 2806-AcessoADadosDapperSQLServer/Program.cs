using Blog.Models;
using Blog.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=NITRO-JN\\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;Trust Server Certificate=True";

ReadUsers();
//ReadUser();
//CreateUser();
//UpdateUser();
//DeleteUser();

static void ReadUsers()
{
    var repository = new UserRepository();
    var users = repository.Get();
    foreach (var user in users)
    {
        Console.WriteLine(user.Name);
    }
}

static void CreateUser()
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var user = new User() 
    {
        Bio = "Equipe balta.io",
        Email = "hello@balta.io",
        Image = "https://...",
        Name = "Equipe balta.io",
        PasswordHash = "hash",
        Slug = "equipe-balta"
    };

    connection.Insert<User>(user);
    Console.WriteLine("Cadastro realizado com sucesso!");
}

static void UpdateUser()
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var user = new User() 
    {
        Id = 2,
        Bio = "Equipe | balta.io",
        Email = "hello@balta.io",
        Image = "https://...",
        Name = "Equipe de suporte balta.io",
        PasswordHash = "hash",
        Slug = "equipe-balta"
    };

    connection.Update<User>(user);
    Console.WriteLine("Cadastro atualizado com sucesso!");
}

static void DeleteUser()
{
    using var connection = new SqlConnection(CONNECTION_STRING);
    var user = connection.Get<User>(2);
    connection.Delete<User>(user);
    Console.WriteLine("Cadastro excluído com sucesso!");
}