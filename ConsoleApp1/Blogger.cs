using Spectre.Console;


namespace BlogManagementSystem
{
    
    public class Blogger : User
    {
        public List<Article> Articles { get; } = new List<Article>();

        public Blogger(string email, string password)
            : base(email, password, UserType.Blogger) { }

        public override void DisplayMenu(List<User> users, List<Article> articles, BlogManagementSystem system)
        {
            AnsiConsole.WriteLine("Bienvenido Blogger");
            AnsiConsole.WriteLine("[1] Ver artículos publicados");
            AnsiConsole.WriteLine("[2] Ver artículos en borrador");
            AnsiConsole.WriteLine("[3] Escribir un nuevo artículo");
            AnsiConsole.WriteLine("[4] Leer artículos de otros bloggers");
            AnsiConsole.WriteLine("[5] Cerrar sesión");

            var choice = AnsiConsole.Prompt(new TextPrompt<int>("Seleccione una opción:"));

            switch (choice)
            {
                case 1:
                    DisplayArticles(Articles);
                    break;
                case 2:
                    DisplayDrafts(Articles);
                    break;
                case 3:
                    WriteArticle();
                    break;
                case 4:
                    ReadOtherArticles(articles);
                    break;
                case 5:
                    AnsiConsole.WriteLine("Cerrando sesión...");
                    break;
                default:
                    AnsiConsole.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void DisplayArticles(List<Article> articles)
        {
            if (articles.Count == 0)
            {
                AnsiConsole.WriteLine("No hay artículos publicados.");
            }
            else
            {
                foreach (var article in articles)
                {
                    AnsiConsole.WriteLine($"Título: {article.Title}");
                    AnsiConsole.WriteLine($"Contenido: {article.Content}");
                    AnsiConsole.WriteLine();
                }
            }
        }

        private void DisplayDrafts(List<Article> articles)
        {
            var drafts = articles.FindAll(a => !a.Published);

            if (drafts.Count == 0)
            {
                AnsiConsole.WriteLine("No hay artículos en borrador.");
            }
            else
            {
                foreach (var draft in drafts)
                {
                    AnsiConsole.WriteLine($"Título: {draft.Title}");
                    AnsiConsole.WriteLine($"Contenido: {draft.Content}");
                    AnsiConsole.WriteLine();
                }
            }
        }

        private void WriteArticle()
        {
            AnsiConsole.WriteLine("Escribiendo un nuevo artículo...");
            AnsiConsole.WriteLine("Ingrese el título del artículo:");
            var title = AnsiConsole.Ask<string>("Título:");
            AnsiConsole.WriteLine("Ingrese el contenido del artículo:");
            var content = AnsiConsole.Ask<string>("Contenido:");
            Articles.Add(new Article(title, content, this));
            AnsiConsole.WriteLine("Artículo guardado correctamente.");
        }

        private void ReadOtherArticles(List<Article> articles)
        {
            AnsiConsole.WriteLine("Leyendo artículos de otros bloggers...");
            
        }
    }

}
