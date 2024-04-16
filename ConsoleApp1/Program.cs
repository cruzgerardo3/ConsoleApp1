using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;


namespace BlogManagementSystem
{
   
    public enum UserType
    {
        Administrator,
        Blogger,
        Reader
    }

    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message) : base(message) { }
    }


    public record Article(string Title, string Content, Blogger Author)
    {
        public bool Published { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var blogManagementSystem = new BlogManagementSystem();
            User currentUser = null;
            bool exitRequested = false;

            while (!exitRequested)
            {
                AnsiConsole.WriteLine("Bienvenido al sistema de gestión de blogs");
                AnsiConsole.WriteLine();

                try
                {
                    
                    if (currentUser == null)
                    {
                        AnsiConsole.WriteLine("Ingrese su correo electrónico:");
                        string email = AnsiConsole.Ask<string>("Email:");

                        AnsiConsole.WriteLine("Ingrese su contraseña:");
                        string password = AnsiConsole.Prompt(new TextPrompt<string>("Contraseña:")
                        {
                            IsSecret = true,
                        });

                        currentUser = blogManagementSystem.Login(email, password);
                    }

                    
                    var articlesList = blogManagementSystem.Articles.ToList();
                    var usersList = blogManagementSystem.Users.ToList();
                    currentUser.DisplayMenu(usersList, articlesList, blogManagementSystem);

                  
                    AnsiConsole.WriteLine("¿Desea cerrar sesión? (S/N)");
                    var logoutChoice = AnsiConsole.Prompt(new TextPrompt<string>("Seleccione S para salir o N para continuar:"));

                    if (logoutChoice.ToLower() == "s")
                    {
                        AnsiConsole.WriteLine("Cerrando sesión...");
                        currentUser = null;
                    }
                }
                catch (InvalidLoginException ex)
                {
                    AnsiConsole.WriteLine($"Error: {ex.Message}");
                    
                    currentUser = null;
                }

                AnsiConsole.WriteLine();
            }
        }
    }

}
