namespace Project.Models;

public class Contract
{
    public int IdContract { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public double Paid { get; set; }
    public string Updates { get; set; } = null!;
    public int DurationInYears { get; set; } = 1; // 1 year by default
    public double AdditionalSupportCost => (DurationInYears - 1) * 1000;
    public bool PreviousClientDiscount { get; set; }
    public SoftwareSystem SoftwareSystem { get; set; } = null!;
    public int IdSoftwareSystem { get; set; }
    public string SoftwareSystemVersion { get; set; } = null!;
    public Client Client { get; set; } = null!;
    public int IdClient { get; set; }
}