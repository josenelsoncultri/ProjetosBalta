using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens;

public static class ListCategoriesScreen
{
    public static void Load()
    {
        Console.Clear();
        
        Console.WriteLine("----- Lista de Categorias -----");
        List();
        
        Console.ReadKey();
    }

    private static void List()
    {
        var repository = new CategoryRepository(Database.Connection);
        var categories = repository.Get();

        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }
    }
}
