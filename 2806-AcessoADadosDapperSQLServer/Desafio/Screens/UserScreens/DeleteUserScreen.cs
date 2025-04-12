using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public static class DeleteUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Excluir usuário -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);

        Delete(id);
    }

    private static void Delete(int Id)
    {
        try
        {
            var repository = new UserRepository(Database.Connection);
            repository.Delete(Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível excluir o usuário, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
