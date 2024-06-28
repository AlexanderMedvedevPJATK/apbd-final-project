using Project.Models;

namespace Project.Repositories.Abstraction;

public interface IContractRepository
{
    Task<ICollection<Contract>> GetAllContractsAsync();
    Task<ICollection<Contract>> GetAllContractsForSoftwareAsync(int softwareId);
    Task<Contract?> FindByIdAsync(int id);
    Task AddAsync(Contract contract);
    Task PayForContractAsync(Contract contract, double amount);
}