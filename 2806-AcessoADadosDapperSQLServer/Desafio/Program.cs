using Blog.Models;
using Blog.Repositories;
using Blog.Utils;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=NITRO-JN\\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;Trust Server Certificate=True";
using var connection = new SqlConnection(CONNECTION_STRING);

connection.Open();

RunCreateMethods(connection);
RunReadMethods(connection);
RunUpdateMethods(connection);
RunReadMethods(connection);
RunDeleteMethods(connection);

connection.Close();

static void RunCreateMethods(SqlConnection connection)
{ 
    var createMethods = new CreateMethods(connection);

    createMethods.CreateUser();
    createMethods.CreateRole();
    createMethods.CreateTag();
}

static void RunReadMethods(SqlConnection connection)
{
    var readMethods = new ReadMethods(connection);

    readMethods.ReadUsers();
    readMethods.ReadRoles();
    readMethods.ReadTags();
}

static void RunUpdateMethods(SqlConnection connection)
{ 
    var updateMethods = new UpdateMethods(connection);

    updateMethods.UpdateUser();
    updateMethods.UpdateRole();
    updateMethods.UpdateTag();
}

static void RunDeleteMethods(SqlConnection connection)
{ 
    var deleteMethods = new DeleteMethods(connection);

    deleteMethods.DeleteUser();
    deleteMethods.DeleteRole();
    deleteMethods.DeleteTag();
}