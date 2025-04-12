namespace Blog.Screens.RoleScreens;

public static class MenuRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("========== Gestão de Perfis ==========");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 -> Cadastrar perfil");
        Console.WriteLine("2 -> Listar todos os perfis");
        Console.WriteLine("3 -> Atualizar perfil");
        Console.WriteLine("4 -> Excluir perfil");

        short option = 0;
        short.TryParse(Console.ReadLine()!, out option);

        switch (option)
        {
            case 0: return;
            case 1: CreateRoleScreen.Load(); break;
            case 2: ListRolesScreen.Load(); break;
            case 3: UpdateRoleScreen.Load(); break;
            case 4: DeleteRoleScreen.Load(); break;
            default: Load(); break;
        }
    }
}
