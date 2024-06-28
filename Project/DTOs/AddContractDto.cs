using System.ComponentModel.DataAnnotations;

namespace Project.DTOs;

public class AddContractDto
{
        
    [Required]
    public int SoftwareSystemId { get; set; }
    
    public string? SoftwareSystemVersion { get; set; }
    
    [Required]
    public string Updates { get; set; } = null!;
    
    [Required]
    public int ClientId { get; set; }
    
    [Required]
    public double BasePrice { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    public int DurationInYears { get; set; } = 1;
    public bool PreviousClientDiscount { get; set; }
}