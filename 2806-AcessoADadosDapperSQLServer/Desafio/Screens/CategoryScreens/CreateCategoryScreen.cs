using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens;

public static class CreateCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Nova categoria -----");
        Console.Write("Nome: "); var name = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;

        Create(new Category() 
        { 
            Name = name,
            Slug = slug
        });
    }

    private static void Create(Category category)
    {
        try
        {
            var repository = new CategoryRepository(Database.Connection);
            repository.Create(category);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar a categoria, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
