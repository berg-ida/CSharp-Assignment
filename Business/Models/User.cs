using Business.Helpers;

namespace Business.Models;

public class User
{
    public string Id = IdGenerator.GenerateId();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;  
}
