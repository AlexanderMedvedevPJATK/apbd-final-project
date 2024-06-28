using Project.DTOs;
using Project.Models;

namespace Project.Repositories.Abstraction;

public interface IIndividualClientsRepository
{
    
    Task<IndividualClient?> FindAsync(int id);
    Task AddAsync(IndividualClient clientDto);
    Task UpdateAsync(IndividualClient clientDto);
    Task DeleteAsync(int id);
}