using Spectre.Console;


namespace BlogManagementSystem
{
    
    public class BlogManagementSystem
    {
        public List<User> Users { get; } = new List<User>();
        public List<Article> Articles { get; } = new List<Article>();

        public BlogManagementSystem()
        {
            Users.AddRange(new User[]
            {
                new Administrator("admin@example.com", "admin123"),
                new Blogger("blogger1@example.com", "b123"),
                new Blogger("blogger2@example.com", "b456"),
                new Blogger("blogger3@example.com", "b789"),
                new Blogger("blogger4@example.com", "b012"),
                new Blogger("blogger5@example.com", "b345"),
                new Reader("reader1@example.com", "r123"),
                new Reader("reader2@example.com", "r456"),
                new Reader("reader3@example.com", "r789"),
                new Reader("reader4@example.com", "r012"),
                new Reader("reader5@example.com", "r345"),
                new Reader("reader6@example.com", "r678"),
                new Reader("reader7@example.com", "r901"),
                new Reader("reader8@example.com", "r234"),
                new Reader("reader9@example.com", "rr567"),
                new Reader("reader10@example.com", "r890"),
            });
        }

        
        public User Login(string email, string password)
        {
            User user = Users.Find(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                throw new InvalidLoginException("Credenciales inválidas.");
            }

            return user;
        }

        
        public void DisplayUsers()
        {
            foreach (var user in Users)
            {
                AnsiConsole.WriteLine($"Email: {user.Email}, Tipo: {user.UserType}");
            }
        }

       
        public void DisplayArticles()
        {
            foreach (var article in Articles)
            {
                AnsiConsole.WriteLine($"Título: {article.Title}");
                AnsiConsole.WriteLine($"Contenido: {article.Content}");
                AnsiConsole.WriteLine($"Autor: {article.Author.Email}");
                AnsiConsole.WriteLine($"Publicado: {(article.Published ? "Sí" : "No")}");
                AnsiConsole.WriteLine();
            }
        }

       
        public void SuspendUser(List<User> users)
        {
            AnsiConsole.WriteLine("Ingrese el correo electrónico del usuario que desea suspender:");
            string email = AnsiConsole.Ask<string>("Email:");

            var user = users.Find(u => u.Email == email);
            if (user != null)
            {
                users.Remove(user);
                AnsiConsole.WriteLine("Usuario suspendido exitosamente.");
            }
            else
            {
                AnsiConsole.WriteLine("No se encontró ningún usuario con ese correo electrónico.");
            }
        }
    }

}
