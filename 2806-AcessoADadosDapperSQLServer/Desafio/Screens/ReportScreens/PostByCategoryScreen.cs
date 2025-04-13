using Blog.Repositories;

namespace Blog.Screens.ReportScreens;

public class PostByCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Posts por Categoria -----");
        Console.Write("Digite a categoria: "); var categoryId = int.Parse(Console.ReadLine()!);
        PostsByCategory(categoryId);

        Console.ReadKey();
    }

    private static void PostsByCategory(int categoryId)
    {
        var categoryRepository = new CategoryRepository(Database.Connection);
        var category = categoryRepository.Get(categoryId);
        var posts = categoryRepository.GetCategoryPosts(categoryId);

        Console.WriteLine($"Categoria: {category.Name}");
        foreach (var post in posts)
        {
            Console.WriteLine(post);
        }
    }
}
