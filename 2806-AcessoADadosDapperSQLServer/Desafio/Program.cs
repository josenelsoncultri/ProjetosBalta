using Blog;
using Blog.Screens.CategoryScreens;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=NITRO-JN\\MSSQLSERVER2022;Database=Blog;User Id=balta;Password=balta;Trust Server Certificate=True";

Database.Connection = new SqlConnection(CONNECTION_STRING);
Database.Connection.Open();

Load();

Console.ReadKey();
Database.Connection.Close();

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
        case 3: MenuCategoriesScreen.Load(); break;
        case 4: MenuTagScreen.Load(); break;
        default: Load(); break;
    }
    Load();
}