using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens;

public static class DeleteCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Excluir categoria -----");
        Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!);

        Delete(id);
    }

    private static void Delete(int Id)
    {
        try
        {
            var repository = new Repository<Category>(Database.Connection);
            repository.Delete(Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível excluir a categoria, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
