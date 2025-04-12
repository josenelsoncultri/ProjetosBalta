using Blog.Repositories;

namespace Blog.Screens.PostScreens;

public class AddTagToPostScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Adicionar Tag ao Post -----");
        Console.Write("Id do Post: "); var postId = int.Parse(Console.ReadLine()!);
        Console.Write("Id do Tag: "); var tagId = int.Parse(Console.ReadLine()!);

        AddTagToPost(postId, tagId);
    }

    private static void AddTagToPost(int postId, int tagId)
    {
        try
        {
            var repository = new PostRepository(Database.Connection);
            repository.AddTag(postId, tagId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível adicionar a tag ao post, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
