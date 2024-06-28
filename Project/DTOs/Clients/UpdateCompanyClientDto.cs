using System.ComponentModel.DataAnnotations;
using Project.Config;

namespace Project.DTOs;

public class UpdateCompanyClientDto
{
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    
    [MaxLength(AppSettings.MaxCompanyNameLength)]
    public string? CompanyName { get; set; }
}