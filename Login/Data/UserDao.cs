using Login.Data;
using Login.Models;

public class UserDao
{
    private readonly AppDbContext _context;

    public UserDao(AppDbContext context)
    {
        _context = context;
    }

    // Retrieves a user from database by username and password
    public User GetUser(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    // Retrieves a user from database by username
    public User GetUserByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    // Add new user to the database
    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}
