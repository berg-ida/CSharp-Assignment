
using Business.Models;

namespace Business.Services;

public class UserService
{
    private List<User> _users = [];
    private readonly FileService _fileService = new FileService(fileName: "users.json");

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public IEnumerable<User> ViewAllUsers()
    {
        return _users;
    }

    public void AddUsersToJson(User user)
    {
        _fileService.SaveListToFile(_users);
    }

    public IEnumerable<User> RetrieveUsersFromJson()
    {
        _users = _fileService.LoadListFromFile();
        return _users;
    }
}
