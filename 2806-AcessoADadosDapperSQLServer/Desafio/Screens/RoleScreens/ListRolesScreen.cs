using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public static class ListRolesScreen
{
    public static void Load()
    {
        Console.Clear();
        
        Console.WriteLine("----- Lista de Perfis -----");
        List();
        
        Console.ReadKey();
    }

    private static void List()
    {
        var repository = new Repository<Role>(Database.Connection);
        var roles = repository.Get();

        foreach (var role in roles)
        {
            Console.WriteLine(role);
        }
    }
}
