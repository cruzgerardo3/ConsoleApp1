using Spectre.Console;


namespace BlogManagementSystem
{
  
    public class Administrator : User
    {
        public Administrator(string email, string password)
            : base(email, password, UserType.Administrator) { }

        public override void DisplayMenu(List<User> users, List<Article> articles, BlogManagementSystem system)
        {
            AnsiConsole.WriteLine("Bienvenido Administrador");
          
            AnsiConsole.WriteLine("[1] Ver usuarios");
            AnsiConsole.WriteLine("[2] Ver artículos");
            AnsiConsole.WriteLine("[3] Suspender usuario");
            AnsiConsole.WriteLine("[4] Cerrar sesión");

            var choice = AnsiConsole.Prompt(new TextPrompt<int>("Seleccione una opción:"));

            switch (choice)
            {
                case 1:
                    system.DisplayUsers();
                    break;
                case 2:
                    system.DisplayArticles();
                    break;
                case 3:
                    system.SuspendUser(users);
                    break;
                case 4:
                    AnsiConsole.WriteLine("Cerrando sesión...");
                    break;
                default:
                    AnsiConsole.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

}
