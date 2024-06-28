namespace Project.Services.Abstraction;

public interface IRevenueService
{
    Task<double> GetRevenueCompany();
    Task<double> GetRevenueSoftware(int idSoftware);
}