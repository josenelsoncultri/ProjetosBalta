using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class UpdateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Atualizar tag -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);
        Console.Write("Nome: "); var name = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;

        Update(new Tag()
        {
            Id = id,
            Name = name,
            Slug = slug
        });
    }

    private static void Update(Tag tag)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection);
            repository.Update(tag);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar a tag, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
