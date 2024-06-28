using Project.Context;
using Project.Models;
using Project.Repositories.Abstraction;

namespace Project.Repositories;

public class SoftwareRepository : ISoftwareRepository
{
    
    private readonly ApbdProjectContext _context;
    
    public SoftwareRepository(ApbdProjectContext context)
    {
        _context = context;
    }
    
    public async Task<SoftwareSystem?> FindByIdAsync(int id)
    {
        return await _context.SoftwareSystems.FindAsync(id);
    }
}