using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class PostRepository(SqlConnection connection) : Repository<Post>(connection)
{
    private readonly SqlConnection _connection = connection;

    public void AddTag(int PostId, int TagId)
    {
        var post = _connection.Get<Post>(PostId);
        if (post is null)
        {
            throw new Exception("Post não encontrado!");
        }

        var tag = _connection.Get<Tag>(TagId);
        if (tag is null)
        {
            throw new Exception("Tag não encontrada!");
        }

        var query = @"INSERT INTO [PostTag] VALUES (@PostId, @TagId)";
        _connection.Execute(query, new
        {
            PostId,
            TagId
        });
    }

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
            A.*,
            T.*
            FROM [Post] P
            LEFT JOIN [Category] C ON (C.[Id] = P.[CategoryId])
            LEFT JOIN [User] A ON (A.[Id] = P.[AuthorId])
            LEFT JOIN [PostTag] PT ON (PT.[PostId] = P.[Id])
            LEFT JOIN [Tag] T ON (T.[Id] = PT.[TagId])
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
                    _post.Tags.Add(tag);

                    posts.Add(_post);
                }
                else
                {
                    _post.Author = author;
                    _post.Category = category;
                    _post.Tags.Add(tag);
                }

                return post;
            },
            splitOn: "Id,Id,Id"
        );

        return posts;
    }
}
