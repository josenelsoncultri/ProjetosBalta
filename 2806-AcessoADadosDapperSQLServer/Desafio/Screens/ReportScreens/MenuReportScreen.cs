namespace Blog.Screens.ReportScreens;

public static class MenuReportScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("========== Relatórios ==========");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 -> Categorias e quantidade de Posts");
        Console.WriteLine("2 -> Tags e quantidade de Posts");

        short option = 0;
        short.TryParse(Console.ReadLine()!, out option);

        switch (option)
        {
            case 0: return;
            case 1: CategoryAndPostCountScreen.Load(); break;
            case 2: TagAndPostCountScreen.Load(); break;
            default: Load(); break;
        }
    }
}
