using Project.Context;
using Project.Models;
using Project.Repositories.Abstraction;

namespace Project.Repositories;

public class ContractRepository : IContractRepository
{
    
    private readonly ApbdProjectContext _context;
    
    public ContractRepository(ApbdProjectContext context)
    {
        _context = context;
    }

    public async Task<Contract?> FindByIdAsync(int id)
    {
        return await _context.Contracts.FindAsync(id);
    }

    public async Task AddAsync(Contract contract)
    {
        await _context.Contracts.AddAsync(contract);
        await _context.SaveChangesAsync(); 
    }

    public async Task PayForContract(Contract contract, double amount)
    {
        contract.Paid += amount;
        await _context.SaveChangesAsync();
    }
}