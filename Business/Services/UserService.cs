
using Business.Models;

namespace Business.Services;

public class UserService
{
    private List<User> _users = [];
    private FileService fileService;
    private readonly FileService _fileService = new FileService(fileName: "users.json");

    public UserService(FileService fileService)
    {
        this.fileService = fileService;
    }

    public bool AddUser(User user)
    {
        try
        {
            _users.Add(user);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<User> ViewAllUsers()
    {
        return _users;
    }

    public bool AddUsersToJson(User user)
    {
        try
        {
            _fileService.SaveListToFile(_users);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<User> RetrieveUsersFromJson()
    {
        _users = _fileService.LoadListFromFile();
        return _users;
    }
}
