using Project.Models;

namespace Project.Repositories.Abstraction;

public interface IContractRepository
{
    Task<Contract?> FindByIdAsync(int id);
    Task AddAsync(Contract contract);
    Task PayForContract(Contract contract, double amount);
}