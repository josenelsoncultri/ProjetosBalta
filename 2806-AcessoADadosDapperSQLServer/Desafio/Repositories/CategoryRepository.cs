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

    public List<Post> GetCategoryPosts(int categoryId)
    {
        var query = @"
            SELECT
            P.*,
            C.*,
            A.*,
            T.*
            FROM [Post] P
            LEFT JOIN [Category] C ON (C.[Id] = P.[CategoryId])
            LEFT JOIN [User] A ON (A.[Id] = P.[AuthorId])
            LEFT JOIN [PostTag] PT ON (PT.[PostId] = P.[Id])
            LEFT JOIN [Tag] T ON (T.[Id] = PT.[TagId])
            WHERE P.[CategoryId] = @CategoryId
        ";

        var posts = new List<Post>();
        var items = _connection.Query<Post, Category, User, Tag, Post>(
            query, (post, category, author, tag) =>
            {
                var _post = posts.FirstOrDefault(x => x.Id == post.Id);
                if (_post is null)
                {
                    _post = post;
                    _post.Author = author;
                    _post.Category = category;

                    if (tag is not null)
                    {
                        _post.Tags.Add(tag);
                    }

                    posts.Add(_post);
                }
                else
                {
                    _post.Author = author;
                    _post.Category = category;

                    if (tag is not null)
                    {
                        _post.Tags.Add(tag);
                    }
                }

                return post;
            },
            param: new 
            { 
                CategoryId = categoryId
            },
            splitOn: "Id,Id,Id"
        );

        return posts;
    }
}
