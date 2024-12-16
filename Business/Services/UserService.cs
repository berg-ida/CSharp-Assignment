
using Business.Models;

namespace Business.Services;

public class UserService
{
    private List<User> _users = [];

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public IEnumerable<User> ViewAllUsers()
    {
        return _users;
    }
}
