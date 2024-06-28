using System.ComponentModel.DataAnnotations;
using Project.Config;

namespace Project.DTOs;

public class UpdateIndividualClientDto
{
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    
    [MaxLength(AppSettings.MaxFirstNameLength)]
    public string? FirstName { get; set; }
    
    [MaxLength(AppSettings.MaxLastNameLength)]
    public string? LastName { get; set; }
}