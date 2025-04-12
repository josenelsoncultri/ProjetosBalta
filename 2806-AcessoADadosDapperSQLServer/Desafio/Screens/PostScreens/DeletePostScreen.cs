using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens;

public static class DeletePostScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Excluir post -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);

        Delete(id);
    }

    private static void Delete(int Id)
    {
        try
        {
            var repository = new PostRepository(Database.Connection);
            repository.Delete(Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível excluir o post, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
