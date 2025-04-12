using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens;

public static class CreatePostScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Criar Post -----");
        Console.Write("Título: "); var title = Console.ReadLine()!;
        Console.Write("Resumo: "); var summary = Console.ReadLine()!;
        Console.Write("Conteúdo: "); var body = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;
        Console.Write("Autor: "); var author = Console.ReadLine()!;
        Console.Write("Categoria: "); var category = Console.ReadLine()!;

        Create(new Post()
        {
            Title = title,
            Summary = summary,
            Body = body,
            Slug = slug,
            AuthorId = int.Parse(author),
            CategoryId = int.Parse(category),
            CreateDate = DateTime.Now,
            LastUpdateDate = DateTime.Now
        });
    }

    private static void Create(Post post)
    {
        try
        {
            var repository = new PostRepository(Database.Connection);
            repository.Create(post);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar o post, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
