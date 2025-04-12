using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens;

public static class UpdateCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Atualizar Categoria -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);
        Console.Write("Nome: "); var name = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;

        Update(new Category()
        {
            Id = id,
            Name = name,
            Slug = slug
        });
    }

    private static void Update(Category category)
    {
        try
        {
            var repository = new Repository<Category>(Database.Connection);
            repository.Update(category);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar a categoria, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
