namespace Blog.Screens.TagScreens;

public static class MenuTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("========== Gestão de Tags ==========");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 -> Cadastrar tag");
        Console.WriteLine("2 -> Listar todas as tags");
        Console.WriteLine("3 -> Atualizar tag");
        Console.WriteLine("4 -> Excluir tag");

        short option = 0;
        short.TryParse(Console.ReadLine()!, out option);

        switch (option)
        {
            case 0: return;
            case 1: CreateTagScreen.Load(); break;
            case 2: ListTagsScreen.Load(); break;
            case 3: UpdateTagScreen.Load(); break;
            case 4: DeleteTagScreen.Load(); break;
            default: Load(); break;
        }
    }
}
