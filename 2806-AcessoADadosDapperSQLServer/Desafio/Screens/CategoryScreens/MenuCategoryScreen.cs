namespace Blog.Screens.CategoryScreens;

public static class MenuCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("========== Gestão de Categorias ==========");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 -> Cadastrar categoria");
        Console.WriteLine("2 -> Listar todas as categorias");
        Console.WriteLine("3 -> Atualizar categoria");
        Console.WriteLine("4 -> Excluir categoria");

        short option = 0;
        short.TryParse(Console.ReadLine()!, out option);

        switch (option)
        {
            case 0: return;
            case 1: CreateCategoryScreen.Load(); break;
            case 2: ListCategoriesScreen.Load(); break;
            case 3: UpdateCategoryScreen.Load(); break;
            case 4: DeleteCategoryScreen.Load(); break;
            default: Load(); break;
        }
    }
}
