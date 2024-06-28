using Microsoft.EntityFrameworkCore;
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

    public async Task<ICollection<Contract>> GetAllContractsAsync()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<ICollection<Contract>> GetAllContractsForSoftwareAsync(int softwareId)
    {
        return await _context.Contracts.Where(c => c.IdSoftwareSystem == softwareId).ToListAsync(); 
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

    public async Task PayForContractAsync(Contract contract, double amount)
    {
        contract.Paid += amount;
        await _context.SaveChangesAsync();
    }
}