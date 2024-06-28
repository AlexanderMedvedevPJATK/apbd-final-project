using Project.DTOs;
using Project.Models;

namespace Project.Repositories.Abstraction;

public interface ICompanyClientsRepository
{
    Task<CompanyClient?> FindAsync(int id);
    Task AddAsync(CompanyClient client);      
    Task UpdateAsync(CompanyClient client);
}