using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public static class DeleteRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Excluir perfil -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);

        Delete(id);
    }

    private static void Delete(int Id)
    {
        try
        {
            var repository = new Repository<Role>(Database.Connection);
            repository.Delete(Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível excluir o perfil, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
