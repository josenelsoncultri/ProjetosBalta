using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public static class CreateRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Novo perfil -----");
        Console.Write("Nome: "); var name = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;

        Create(new Role() 
        { 
            Name = name,
            Slug = slug
        });
    }

    private static void Create(Role role)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
            repository.Create(role);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar o perfil, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
