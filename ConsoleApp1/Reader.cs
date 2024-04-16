using Spectre.Console;


namespace BlogManagementSystem
{
   
    public class Reader : User
    {
        public Reader(string email, string password)
            : base(email, password, UserType.Reader) { }

        public override void DisplayMenu(List<User> users, List<Article> articles, BlogManagementSystem blogSystem)
        {
            AnsiConsole.WriteLine("Bienvenido Lector");
            AnsiConsole.WriteLine("[1] Leer blogs publicados");
            AnsiConsole.WriteLine("[2] Cerrar sesión");

            var choice = AnsiConsole.Prompt(new TextPrompt<int>("Seleccione una opción:"));

            switch (choice)
            {
                case 1:
                    DisplayPublishedArticles(articles);
                    break;
                case 2:
                    AnsiConsole.WriteLine("Cerrando sesión...");
                    break;
                default:
                    AnsiConsole.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void DisplayPublishedArticles(List<Article> articles)
        {
            var publishedArticles = articles.Where(a => a.Published).ToList();
            if (publishedArticles.Count == 0)
            {
                AnsiConsole.WriteLine("No hay artículos publicados.");
            }
            else
            {
                foreach (var article in publishedArticles)
                {
                    AnsiConsole.WriteLine($"Título: {article.Title}");
                    AnsiConsole.WriteLine($"Contenido: {article.Content}");
                    AnsiConsole.WriteLine($"Autor: {article.Author.Email}");
                    AnsiConsole.WriteLine();
                }
            }
        }
    }

}
