namespace Project.Models;

public abstract class Client
{
    public int IdClient { get; set; }
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}