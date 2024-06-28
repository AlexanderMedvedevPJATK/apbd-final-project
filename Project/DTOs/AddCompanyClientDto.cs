using System.ComponentModel.DataAnnotations;
using Project.Config;

namespace Project.DTOs;

public class CompanyClientDto
{
    [Required]
    public string Address { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string PhoneNumber { get; set; } = null!;
    
    [Required]
    [MaxLength(AppSettings.MaxCompanyNameLength)]
    public string CompanyName { get; set; } = null!;
    
    [Required]
    [MaxLength(AppSettings.KrsLength)]
    public string KrsNumber { get; set; } = null!;
}