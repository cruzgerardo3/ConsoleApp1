namespace BlogManagementSystem
{
    public interface IUser
    {
        string Email { get; }
        string Password { get; }
        UserType UserType { get; }
        void DisplayMenu(List<User> users, List<Article> articles, BlogManagementSystem system);
    }

}
