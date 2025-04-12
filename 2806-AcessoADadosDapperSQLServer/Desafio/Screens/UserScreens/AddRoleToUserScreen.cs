using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public class AddRoleToUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Adicionar Perfil ao Usuário -----");
        Console.Write("Id do Usuário: "); var userId = int.Parse(Console.ReadLine()!);
        Console.Write("Id do Perfil: "); var roleId = int.Parse(Console.ReadLine()!);

        AddRoleToUser(userId, roleId);
    }

    private static void AddRoleToUser(int userId, int roleId)
    {
        try
        {
            var repository = new UserRepository(Database.Connection);
            repository.AddRole(userId, roleId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível adicionar o perfil ao usuário, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
