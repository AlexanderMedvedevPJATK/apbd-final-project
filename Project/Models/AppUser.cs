namespace Project.Models;

public class AppUser
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Roles { get; set; } = null!;
}