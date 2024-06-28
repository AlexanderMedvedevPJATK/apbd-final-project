using Project.Context;
using Project.Exceptions;
using Project.Models;
using Project.Repositories.Abstraction;

namespace Project.Repositories;

public class IndividualClientsRepository : IIndividualClientsRepository
{
    private readonly ApbdProjectContext _context;
    
    public IndividualClientsRepository(ApbdProjectContext context)
    {
        _context = context;
    }
    
    public async Task<IndividualClient?> FindAsync(int id)
    {
        return await _context.IndividualClients.FindAsync(id);
    }

    public async Task AddAsync(IndividualClient clientDto)
    {
        await _context.IndividualClients.AddAsync(clientDto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(IndividualClient clientDto)
    {
        _context.IndividualClients.Update(clientDto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var client = await _context.IndividualClients.FindAsync(id);
        if (client != null)
        {
            if (client.IsDeleted)
            {
                throw new ClientAlreadyDeletedException("Client already deleted");
            }
            
            client.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ClientNotFoundException("Client not found");
        }
    }
}