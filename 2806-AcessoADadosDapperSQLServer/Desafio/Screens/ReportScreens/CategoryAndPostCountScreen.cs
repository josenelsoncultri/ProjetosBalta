using Blog.Repositories;

namespace Blog.Screens.ReportScreens;

public class CategoryAndPostCountScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Categorias e Quantidade de Posts -----");

        CategoryAndPostCount();

        Console.ReadKey();
    }

    private static void CategoryAndPostCount()
    {
        var repository = new CategoryRepository(Database.Connection);

        var items = repository.GetCategoriesAndPostCount();

        foreach (var item in items)
        {
            Console.WriteLine($"Categoria: {item.Item1} - Quantidade de Posts: {item.Item2}");
        }
    }
}