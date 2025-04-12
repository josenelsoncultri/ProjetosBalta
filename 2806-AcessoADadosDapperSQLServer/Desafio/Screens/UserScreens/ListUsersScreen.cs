using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public static class ListUsersScreen
{
    public static void Load()
    {
        Console.Clear();
        
        Console.WriteLine("----- Lista de Usuários -----");
        List();
        
        Console.ReadKey();
    }

    private static void List()
    {
        var repository = new UserRepository(Database.Connection);
        var users = repository.GetWithRoles();

        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}
