namespace BlogManagementSystem
{
   
    public abstract class User : IUser
    
    
    {
        public string Email { get; }
        public string Password { get; }
        public UserType UserType { get; }

        protected User(string email, string password, UserType userType)
        {
            Email = email;
            Password = password;
            UserType = userType;
        }

        public abstract void DisplayMenu(List<User> users, List<Article> articles, BlogManagementSystem system);
        
    }

}
