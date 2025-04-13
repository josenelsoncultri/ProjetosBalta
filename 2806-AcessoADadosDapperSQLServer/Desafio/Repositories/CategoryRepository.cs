using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class CategoryRepository(SqlConnection connection) : Repository<Category>(connection)
{
    private readonly SqlConnection _connection = connection;

    public IEnumerable<(string, int)> GetCategoriesAndPostCount()
    {
        var query = @"
            SELECT
            C.[Name] AS [Category],
            COUNT(P.[Id]) AS [PostCount]
            FROM [Category] C
            LEFT JOIN [Post] P ON (P.[CategoryId] = C.[Id])
            GROUP BY C.[Name]
        ";

        var items = _connection.Query<(string, int)>(
            query, ((string, int) item) => 
            {
                return item;
            }
        );

        return items;
    }
}
