using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class TagRepository(SqlConnection connection) : Repository<Tag>(connection)
{
    private readonly SqlConnection _connection = connection;

    public IEnumerable<(string, int)> GetTagsAndPostCount()
    {
        var query = @"
            SELECT
            T.[Name] AS [Tag],
            COUNT(PT.[PostId]) AS [PostCount]
            FROM [Tag] T
            LEFT JOIN [PostTag] PT ON (PT.[TagId] = T.[Id])
            GROUP BY T.[Name]
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
