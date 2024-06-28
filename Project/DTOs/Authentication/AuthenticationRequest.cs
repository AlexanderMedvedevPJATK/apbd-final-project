using System.ComponentModel.DataAnnotations;

namespace Project.DTOs.Authentication;

public class AuthenticationRequest
{
    [Required]
    public string Login { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}
