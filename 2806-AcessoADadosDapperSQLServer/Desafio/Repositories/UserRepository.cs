﻿    using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository(SqlConnection connection) : Repository<User>(connection)
{
    private readonly SqlConnection _connection = connection;

    public void AddRole(int UserId, int RoleId)
    {
        var user = _connection.Get<User>(UserId);
        if (user is null)
        {
            throw new Exception("Usuário não encontrado!");
        }

        var role = _connection.Get<Role>(RoleId);
        if (role is null)
        {
            throw new Exception("Perfil não encontrado!");
        }

        var query = @"INSERT INTO [UserRole] VALUES (@UserId, @RoleId)";
        _connection.Execute(query, new 
        { 
            UserId,
            RoleId
        });
    }

    public List<User> GetWithRoles()
    {
        var query = @"
            SELECT
	            [User].*,
	            [Role].*
            FROM [User]
            LEFT JOIN [UserRole] ON ([UserRole].UserId = [User].Id)
            LEFT JOIN [Role] ON ([Role].Id = [UserRole].RoleId)
        ";

        var users = new List<User>();
        var items = _connection.Query<User, Role, User>(
            query, (user, role) => 
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr is null)
                {
                    usr = user;
                    if (role != null)
                    {
                        usr.Roles.Add(role);
                    }
                    users.Add(usr);
                }
                else
                {
                    usr.Roles.Add(role);
                }

                return user;
            },
            splitOn: "Id"
        );

        return users;
    }
}
