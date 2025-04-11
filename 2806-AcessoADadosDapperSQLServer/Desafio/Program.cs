using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=NITRO-JN\\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;Trust Server Certificate=True";
using var connection = new SqlConnection(CONNECTION_STRING);

connection.Open();

Load();

Console.ReadKey();
connection.Close();

static void Load()
{
    Console.Clear();
    Console.WriteLine("========== BLOG ==========");
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine("1 -> Gestão de usuário");
    Console.WriteLine("2 -> Gestão de perfil");
    Console.WriteLine("3 -> Gestão de categoria");
    Console.WriteLine("4 -> Gestão de tag");
    Console.WriteLine("5 -> Vincular perfil/usuário");
    Console.WriteLine("6 -> Vincular post/tag");
    Console.WriteLine("7 -> Relatórios");
    Console.WriteLine("Nenhuma opção -> Sair");

    short option = 0;
    short.TryParse(Console.ReadLine()!, out option);

    switch (option)
    {
        case 0: return;
        case 4: MenuTagScreen.Load(); break;
        default: Load(); break;
    }
    Load();
}