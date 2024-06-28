namespace Project.Models;

public class Discount
{
    public int IdDiscount { get; set; }
    public string Name { get; set; } = null!;
    public bool ForSubscription { get; set; }
    public bool ForUpfront { get; set; }
    public double Percentage { get; set; }  // 0.0 - 1.0
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<SoftwareSystem> SoftwareSystems { get; set; } = new List<SoftwareSystem>();
}