using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class DeleteTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Excluir tag -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);

        Delete(id);
    }

    private static void Delete(int Id)
    {
        try
        {
            var repository = new TagRepository(Database.Connection);
            repository.Delete(Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível excluir a tag, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
