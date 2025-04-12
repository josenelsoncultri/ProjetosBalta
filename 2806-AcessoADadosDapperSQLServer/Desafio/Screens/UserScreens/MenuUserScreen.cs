namespace Blog.Screens.UserScreens;

public static class MenuUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("========== Gestão de Usuários ==========");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 -> Cadastrar usuário");
        Console.WriteLine("2 -> Listar todos os usuários");
        Console.WriteLine("3 -> Atualizar usuário");
        Console.WriteLine("4 -> Excluir usuário");
        Console.WriteLine("5 -> Vincular perfil ao usuário");

        short option = 0;
        short.TryParse(Console.ReadLine()!, out option);

        switch (option)
        {
            case 0: return;
            case 1: CreateUserScreen.Load(); break;
            case 2: ListUsersScreen.Load(); break;
            case 3: UpdateUserScreen.Load(); break;
            case 4: DeleteUserScreen.Load(); break;
            case 5: AddRoleToUserScreen.Load(); break;
            default: Load(); break;
        }
    }
}
