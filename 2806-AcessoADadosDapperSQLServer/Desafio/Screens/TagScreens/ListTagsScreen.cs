using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class ListTagsScreen
{
    public static void Load()
    {
        Console.Clear();
        
        Console.WriteLine("----- Lista de Tags -----");
        List();
        
        Console.ReadKey();
    }

    private static void List()
    {
        var repository = new Repository<Tag>(Database.Connection);
        var tags = repository.Get();

        foreach (var tag in tags)
        {
            Console.WriteLine(tag);
        }
    }
}
