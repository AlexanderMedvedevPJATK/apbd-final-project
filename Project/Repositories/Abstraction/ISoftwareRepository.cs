using Project.Models;

namespace Project.Repositories.Abstraction;

public interface ISoftwareRepository
{
    Task<SoftwareSystem?> FindByIdAsync(int id);
}