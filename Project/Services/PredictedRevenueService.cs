using Project.Repositories.Abstraction;
using Project.Services.Abstraction;

namespace Project.Services;

public class PredictedRevenueService : IPredictedRevenueService
{
    private readonly IContractRepository _contractRepository;
    private readonly ISoftwareRepository _softwareRepository;

    public PredictedRevenueService(IContractRepository contractRepository, ISoftwareRepository softwareRepository)
    {
        _contractRepository = contractRepository;
        _softwareRepository = softwareRepository;
    }

    public async Task<double> GetPredictedRevenueCompany()
    {
        var contracts = await _contractRepository.GetAllContractsAsync();
        return contracts.Sum(c => c.Price);
    }

    public async Task<double> GetPredictedRevenueSoftware(int idSoftware)
    {
        var contracts = await _contractRepository.GetAllContractsForSoftwareAsync(idSoftware);
        return contracts.Sum(c => c.Price);
    }
}