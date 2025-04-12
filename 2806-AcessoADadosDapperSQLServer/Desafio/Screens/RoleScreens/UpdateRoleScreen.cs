using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public static class UpdateRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Atualizar Perfil -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);
        Console.Write("Nome: "); var name = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;

        Update(new Role()
        {
            Id = id,
            Name = name,
            Slug = slug
        });
    }

    private static void Update(Role role)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
            repository.Update(role);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar o perfil, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
