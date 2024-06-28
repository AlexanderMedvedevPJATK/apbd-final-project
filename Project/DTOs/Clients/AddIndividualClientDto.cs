

using System.ComponentModel.DataAnnotations;
using Project.Config;

namespace Project.DTOs;

public class AddIndividualClientDto
{
    [Required]
    public string Address { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string PhoneNumber { get; set; } = null!;
    
    [Required]
    [MaxLength(AppSettings.MaxFirstNameLength)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(AppSettings.MaxLastNameLength)]
    public string LastName { get; set; } = null!;
    
    [Required]
    [MaxLength(AppSettings.PeselLength)]
    public string Pesel { get; set; } = null!;
}