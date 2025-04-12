using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens;

public static class ListPostsScreen
{
    public static void Load()
    {
        Console.Clear();
        
        Console.WriteLine("----- Lista de Posts -----");
        List();
        
        Console.ReadKey();
    }

    private static void List()
    {
        var repository = new PostRepository(Database.Connection);
        var posts = repository.GetWithAuthorAndCategory();

        foreach (var post in posts)
        {
            Console.WriteLine(post);
        }
    }
}
