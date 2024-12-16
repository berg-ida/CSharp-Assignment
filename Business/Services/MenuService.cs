
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class MenuService
{
    UserService userService = new UserService();
    FileService fileService = new FileService();
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("-----------CONTACT APPLICATION-----------");
        Console.WriteLine("");
        Console.WriteLine($"{"[1]",-10} Create a contact ");
        Console.WriteLine($"{"[2]",-10} View all contacts ");
        Console.WriteLine($"{"[3]",-10} Save contacts");
        Console.WriteLine($"{"[4]",-10} Retrive previous contacts");
        Console.WriteLine($"{"[5]",-10} Quit application");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                {
                    AddContact();
                    break;
                }
            case "2":
                {
                    ViewAllContacts();
                    break;
                }
            case "3":
                {
                    SaveContactsToJson();
                    break;
                }
            case "4":
                {
                    RetriveContacts();
                    break;
                }
            case "5":
                {
                    QuitApplication(); 
                    break;
                }
        }
    }

    public void AddContact()
    {
        User user = new User();

        Console.Clear();
        Console.WriteLine("---------------ADD CONTACT---------------");
        Console.WriteLine("");
        Console.WriteLine("Please give the contact a... ");
        Console.Write("First name: ");
        user.FirstName = Console.ReadLine()!;
        Console.Write("Last name: ");
        user.LastName = Console.ReadLine()!;
        Console.Write("Email adress: ");
        user.Email = Console.ReadLine()!;
        Console.Write("Phone number: ");
        user.PhoneNumber = Console.ReadLine()!;
        Console.Write("Adress: ");
        user.Adress = Console.ReadLine()!;
        Console.Write("Zipcode: ");
        user.ZipCode = Console.ReadLine()!;
        Console.Write("City: ");
        user.City = Console.ReadLine()!;

        userService.AddUser(user);
        Console.WriteLine("Contact added successfully.");
        Console.ReadLine();
    }

    public void ViewAllContacts()
    {
        Console.Clear();
        Console.WriteLine("--------------VIEW ALL USERS-------------");
        Console.WriteLine("");

        foreach (var user in userService.ViewAllUsers())
        {
            Console.WriteLine("");
            Console.WriteLine($"{"Id: ",-10} {user.Id}");
            Console.WriteLine($"{"Name: ",-10} {user.FirstName} {user.LastName}");
            Console.WriteLine($"{"Email: ",-10} {user.Email}");
            Console.WriteLine($"{"Phone: ",-10} {user.PhoneNumber}");
            Console.WriteLine($"{"Adress: ",-10} {user.Adress}");
            Console.WriteLine($"{"Zipcode: ",-10} {user.ZipCode}");
            Console.WriteLine($"{"City: ",-10} {user.City}");
        }

        Console.ReadLine();
    }

    public void SaveContactsToJson()
    {
        User user = new User();

        Console.Clear();
        Console.WriteLine("--------------SAVE CONTACTS--------------");
        Console.WriteLine("");
        try
        {
            userService.AddUsersToJson(user);
            Console.WriteLine("Succesfully saved contacts to file.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    public void RetriveContacts()
    {
        Console.Clear();
        Console.WriteLine("------------RETRIEVE CONTACTS------------");
        Console.WriteLine("");
        try
        {
            userService.RetrieveUsersFromJson();
            Console.WriteLine("Succesfully retrieved contacts from file.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    public void QuitApplication()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to quit the application? (Y/N)");
        var quitOption = Console.ReadLine()!;

        if (quitOption.ToLower() == "y")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Returning to application.");
        }
        Console.ReadLine();
    }
}
