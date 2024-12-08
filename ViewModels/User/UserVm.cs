namespace E_Commerce.Models.User;

public class UserVm
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // Admin, Customer, etc.
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateJoined { get; set; }

   
}