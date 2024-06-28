namespace Project.Services.Abstraction;

public interface IPredictedRevenueService
{
    Task<double> GetPredictedRevenueCompany();
    Task<double> GetPredictedRevenueSoftware(int idSoftware);
}