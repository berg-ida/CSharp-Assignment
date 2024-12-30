using Business.Services;
using Business.Models;
using Business.Helpers;
using System.Text.Json;

namespace ContactConsole.MainApp.Tests.Services;

public class UserService_Tests
{
    private readonly UserService _userService;
    private readonly FileService _fileService;
    private readonly string _directoryPath = "TestData";
    private readonly string _fileName = "test_users.json";

    public UserService_Tests()
    {
        _fileService = new FileService(_directoryPath, _fileName);
        _userService = new UserService(_fileService);
    }

    [Fact]
    public void AddUser_ShouldReturnTrueWhenUserIsAdded()
    {
        //arrange
        var user = new User {
            Id = IdGenerator.GenerateId(),
            FirstName = "Test Firstname",
            LastName = "Test Lastname",
            Email = "Test Email",
            PhoneNumber = "Test Phonenumber",
            Adress = "Test Adress",
            ZipCode = "Test Zipcode",
            City = "Test City"
        };

        //act
        bool result = _userService.AddUser(user);

        //assert
        Assert.True(result);
    }


    [Fact]
    public void ViewAllUsers_ShouldReturnUserList()
    {
        //arrange
        var userService = new UserService(_fileService);
        var user = new User
        {
            Id = IdGenerator.GenerateId(),
            FirstName = "Test Firstname",
            LastName = "Test Lastname",
            Email = "Test Email",
            PhoneNumber = "Test Phonenumber",
            Adress = "Test Adress",
            ZipCode = "Test Zipcode",
            City = "Test City"
        };
        userService.AddUser(user);
        

        //act
        var result = userService.ViewAllUsers();

        //assert
        Assert.NotNull(result);
        var users = new List<User>(result);
        Assert.Contains(user, users);
    }


    [Fact]
    public void AddUserToJson_ShouldReturnTrueWhenSuccessful()
    {
        //arrange
        var user = new User
        {
            Id = IdGenerator.GenerateId(),
            FirstName = "Test Firstname",
            LastName = "Test Lastname",
            Email = "Test Email",
            PhoneNumber = "Test Phonenumber",
            Adress = "Test Adress",
            ZipCode = "Test Zipcode",
            City = "Test City"
        };

        //act
        bool result = _userService.AddUsersToJson(user);

        //assert
        Assert.True(result);
    }


    [Fact]
    public void RetrieveUsersFromJson_ShouldReturnUsersFromFile()
    {
        //arrange
        var directoryPath = Path.Combine(Environment.CurrentDirectory, "TestData");
        var fileName = "test_list.json";
        var filePath = Path.Combine(directoryPath, fileName);
        var fileService = new FileService(directoryPath, fileName);
        var userService = new UserService(fileService);
        
        try
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var user = new User
            {
                Id = IdGenerator.GenerateId(),
                FirstName = "Test Firstname",
                LastName = "Test Lastname",
                Email = "Test Email",
                PhoneNumber = "Test Phonenumber",
                Adress = "Test Adress",
                ZipCode = "Test Zipcode",
                City = "Test City"
            };
            var testUsers = new List<User> { user };

            var json = JsonSerializer.Serialize(testUsers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);

            //act
            userService.AddUsersToJson(user);
            var result = userService.RetrieveUsersFromJson();
            

            //assert
            Assert.NotNull(result);
            Assert.Contains(user, testUsers);

        }
        finally
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (Directory.Exists(directoryPath) && Directory.GetFiles(directoryPath).Length == 0)
            {
                Directory.Delete(directoryPath);
            }
        }
    }
}
