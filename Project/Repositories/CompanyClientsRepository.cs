using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;
using Project.Repositories.Abstraction;

namespace Project.Repositories;

public class CompanyClientsRepository : ICompanyClientsRepository
{
    
    private readonly ApbdProjectContext _context;
    
    public CompanyClientsRepository(ApbdProjectContext context)
    {
        _context = context;
    }
    
    public async Task<CompanyClient?> FindAsync(int id)
    {
        return await _context.CompanyClients.FindAsync(id);
    }

    public async Task AddAsync(CompanyClient client)
    {
        await _context.CompanyClients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CompanyClient client)
    {
        _context.CompanyClients.Update(client);
        await _context.SaveChangesAsync();
    }
}