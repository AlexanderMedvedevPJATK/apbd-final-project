namespace Project.Models;

public class SoftwareSystem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string Category { get; set; } = null!;
    public double YearlyPrice { get; set; }
    public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    
    public Discount GetMaximalDiscount()
    {
        var maximalDiscount = Discounts.First();
        foreach (var discount in Discounts)
        {
            if (discount.Percentage > maximalDiscount.Percentage)
            {
                maximalDiscount = discount;
            }
        }

        return maximalDiscount;
    }
}