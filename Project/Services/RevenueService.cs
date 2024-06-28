using Microsoft.AspNetCore.Mvc;
using Project.Exceptions;
using Project.Repositories.Abstraction;
using Project.Services.Abstraction;

namespace Project.Services;

public class RevenueService : IRevenueService
{
    private readonly IContractRepository _contractRepository;
    private readonly ISoftwareRepository _softwareRepository;
    
    public RevenueService(IContractRepository contractRepository, ISoftwareRepository softwareRepository)
    {
        _contractRepository = contractRepository;
        _softwareRepository = softwareRepository;
    }
    
    public async Task<double> GetRevenueCompany()
    {
        var contracts = await _contractRepository.GetAllContractsAsync();
        return contracts.Where(c => Math.Abs(c.Paid - c.Price) < 0.01).Sum(c => c.Paid);
    }

    public async Task<double> GetRevenueSoftware(int idSoftware)
    {
        if (await _softwareRepository.FindByIdAsync(idSoftware) == null)
        {
            throw new SoftwareNotFoundException("Software not found");
        }
        
        var contracts = await _contractRepository.GetAllContractsForSoftwareAsync(idSoftware);
        return contracts.Where(c => Math.Abs(c.Paid - c.Price) < 0.01).Sum(c => c.Paid);
    }
    
}