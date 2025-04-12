using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class PostRepository(SqlConnection connection) : Repository<Post>(connection)
{
    private readonly SqlConnection _connection = connection;

    public void UpdatePost(Post post)
    {
        var query = @"
            UPDATE [POST]
            SET [Title] = @Title,
            [Summary] = @Summary,
            [Body] = @Body,
            [Slug] = @Slug,
            [LastUpdateDate] = @LastUpdateDate,
            [AuthorId] = @AuthorId,
            [CategoryId] = @CategoryId
            WHERE [Id] = @Id
        ";
        var rows = connection.Execute(query, new
        {
            post.Title,
            post.Summary,
            post.Body,
            post.Slug,
            post.LastUpdateDate,
            post.AuthorId,
            post.CategoryId,
            post.Id
        });
    }

    public List<Post> GetWithAuthorAndCategory()
    {
        var query = @"
            SELECT
            P.*,
            C.*,
            A.*
            FROM [Post] P
            LEFT JOIN [Category] C ON (C.[Id] = P.[CategoryId])
            LEFT JOIN [User] A ON (A.[Id] = P.[AuthorId])
        ";

        var posts = new List<Post>();
        var items = _connection.Query<Post, Category, User, Post>(
            query, (post, category, author) =>
            {
                var _post = posts.FirstOrDefault(x => x.Id == post.Id);
                if (_post is null)
                {
                    _post = post;
                    _post.Author = author;
                    _post.Category = category;

                    posts.Add(_post);
                }
                else
                {
                    _post.Author = author;
                    _post.Category = category;
                }

                return post;
            },
            splitOn: "Id,Id"
        );

        return posts;
    }
}
