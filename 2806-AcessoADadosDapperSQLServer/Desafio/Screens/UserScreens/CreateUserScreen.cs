using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public static class CreateUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("----- Novo usuário -----");
        Console.Write("Nome: "); var name = Console.ReadLine()!;
        Console.Write("Email: "); var email = Console.ReadLine()!;
        Console.Write("Senha: "); var passwordHash = Console.ReadLine()!;
        Console.Write("Bio: "); var bio = Console.ReadLine()!;
        Console.Write("Foto: "); var image = Console.ReadLine()!;
        Console.Write("Slug: "); var slug = Console.ReadLine()!;

        Create(new User() 
        { 
            Name = name,
            Email = email,
            PasswordHash = passwordHash,
            Bio = bio,
            Image = image,
            Slug = slug
        });
    }

    private static void Create(User user)
    {
        try
        {
            var repository = new UserRepository(Database.Connection);
            repository.Create(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível salvar o usuário, detalhes do erro: {ex.Message} - {ex.StackTrace}");
        }
    }
}
