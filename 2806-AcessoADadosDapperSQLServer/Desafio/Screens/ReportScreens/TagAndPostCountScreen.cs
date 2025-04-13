using Blog.Repositories;

namespace Blog.Screens.ReportScreens;

public class TagAndPostCountScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Tags e Quantidade de Posts -----");

        TagAndPostCount();

        Console.ReadKey();
    }

    private static void TagAndPostCount()
    {
        var repository = new TagRepository(Database.Connection);

        var items = repository.GetTagsAndPostCount();

        foreach (var item in items)
        {
            Console.WriteLine($"Tag: {item.Item1} - Quantidade de Posts: {item.Item2}");
        }
    }
}