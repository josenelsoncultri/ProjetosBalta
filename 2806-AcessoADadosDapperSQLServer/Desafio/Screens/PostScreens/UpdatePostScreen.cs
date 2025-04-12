using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens;

public static class UpdatePostScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Atualizar Post -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);
        Console.Write("Título: "); var title = Console.ReadLine()!;
        Console.Write("Resumo: "); var summary = Console.ReadLine()!;
        Console.Write("Conteúdo: "); var body = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;
        Console.Write("Autor: "); var author = Console.ReadLine()!;
        Console.Write("Categoria: "); var category = Console.ReadLine()!;


        Update(new Post()
        {
            Id = id,
            Title = title,
            Summary = summary,
            Body = body,
            Slug = slug,
            AuthorId = int.Parse(author),
            CategoryId = int.Parse(category),
            LastUpdateDate = DateTime.Now
        });
    }

    private static void Update(Post post)
    {
        try
        {
            var repository = new PostRepository(Database.Connection);
            repository.UpdatePost(post);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar o post, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
