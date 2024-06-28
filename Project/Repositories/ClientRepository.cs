using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;
using Project.Repositories.Abstraction;

namespace Project.Repositories;

public class ClientRepository : IClientRepository
{
    
    private readonly ApbdProjectContext _context;
    
    public ClientRepository(ApbdProjectContext context)
    {
        _context = context;
    }
    
    public async Task<Client?> FindByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<bool> ClientHasContractOnThisSoftware(int clientId, int softwareId)
    {
        return await _context.Contracts.AnyAsync(c => c.IdClient == clientId && c.IdSoftwareSystem == softwareId);
    }
}