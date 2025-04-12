namespace Blog.Screens.PostScreens;

public static class MenuPostScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("========== Gestão de Posts ==========");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 -> Criar post");
        Console.WriteLine("2 -> Listar todos os post");
        Console.WriteLine("3 -> Atualizar post");
        Console.WriteLine("4 -> Excluir post");

        short option = 0;
        short.TryParse(Console.ReadLine()!, out option);

        switch (option)
        {
            case 0: return;
            case 1: CreatePostScreen.Load(); break;
            case 2: ListPostsScreen.Load(); break;
            case 3: UpdatePostScreen.Load(); break;
            case 4: DeletePostScreen.Load(); break;
            default: Load(); break;
        }
    }
}
